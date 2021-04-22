using System;
using System.Collections.Generic;
using System.Text;
using PsychologyPatientSystem.Core.Entities.Concrete;
using PsychologyPatientSystem.Core.Utilities.Results;

namespace PsychologyPatientSystem.Business.Abstract
{
  public  interface IUserService
  {
      IDataResult<List<User>> GetAll();
      IDataResult<List<OperationClaim>> GetClaims(User user);
      IDataResult<User> GetByMail(string email);
      IResult Add(User user);
      IResult Update(User user);
      IResult Delete(User user);
  }
}
