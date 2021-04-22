using System;
using System.Collections.Generic;
using System.Text;
using PsychologyPatientSystem.Core.Entities.Concrete;
using PsychologyPatientSystem.Core.Utilities.Results;
using PsychologyPatientSystem.Core.Utilities.Security.Jwt;
using PsychologyPatientSystem.Entities.Dto;

namespace PsychologyPatientSystem.Business.Abstract
{
   public interface IAuthService
   {
       IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
       IDataResult<User> Login(UserForLoginDto userForLoginDto);
       IResult UserExits(string email);
       IDataResult<AccessToken> CreateAccessToken(User user);
   }
}
