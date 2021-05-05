using System;
using System.Collections.Generic;
using System.Text;
using PsychologyPatientSystem.Business.Abstract;
using PsychologyPatientSystem.Core.Entities.Concrete;
using PsychologyPatientSystem.Core.Utilities.Results;
using PsychologyPatientSystem.DataAccess.Abstract;

namespace PsychologyPatientSystem.Business.Concrete
{
   public class UserManager:IUserService
   {
       private IUserDal _userDal;

       public UserManager(IUserDal userDal)
       {
           _userDal = userDal;
       }
       public IDataResult<List<User>> GetAll()
       {
           _userDal.GetAll();
           return new SuccessDataResult<List<User>>();
       }

        public List<OperationClaim> GetClaims(User user)
        {
           
              return _userDal.OperationClaims(user);
        }

        public User GetByMail(string email)
        {

            return _userDal.Get(u => u.Email == email);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
           _userDal.Update(user);
           return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }
    }
}
