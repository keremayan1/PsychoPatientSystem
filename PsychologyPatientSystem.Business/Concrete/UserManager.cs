﻿using System;
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

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            _userDal.OperationClaims(user);
            return new SuccessDataResult<List<OperationClaim>>();
        }

        public IDataResult<User> GetByMail(string email)
        {
            _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>();
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