 using System;
using System.Collections.Generic;
using System.Text;
using PsychologyPatientSystem.Business.Abstract;
using PsychologyPatientSystem.Business.Constants;
using PsychologyPatientSystem.Core.Entities.Concrete;
using PsychologyPatientSystem.Core.Utilities.Results;
using PsychologyPatientSystem.Core.Utilities.Security.Hashing;
using PsychologyPatientSystem.Core.Utilities.Security.Jwt;
using PsychologyPatientSystem.Entities.Dto;

namespace PsychologyPatientSystem.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
              
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck);
        }

        public IResult UserExits(string email)
        {

            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExits);
            }

            var result = _userService.GetByMail(email);
            if (result!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExits);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateAccessToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Access token created");
        }
    }
}
