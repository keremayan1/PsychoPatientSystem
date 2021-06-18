using PsychologyPatientSystem.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using PsychologyPatientSystem.Core.Entities.Concrete;

namespace PsychologyPatientSystem.DataAccess.Abstract
{
   public interface IUserDal:IEntityRepository<User>,IAsyncEntityRepository<User>
   {
       List<OperationClaim> OperationClaims(User user);
   }
}
