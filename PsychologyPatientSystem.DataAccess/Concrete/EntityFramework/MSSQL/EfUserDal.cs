using System.Collections.Generic;
using System.Linq;
using PsychologyPatientSystem.Core.DataAccess.EntityFramework;
using PsychologyPatientSystem.Core.Entities.Concrete;
using PsychologyPatientSystem.DataAccess.Abstract;
using PsychologyPatientSystem.DataAccess.Concrete.EntityFramework.MSSQL.Context;


namespace PsychologyPatientSystem.DataAccess.Concrete.EntityFramework.MSSQL
{
    public class EfUserDal:EfEntityRepository<User,PsychologyPatientSystemContext>,IUserDal
    {
        public List<OperationClaim> OperationClaims(User user)
        {
          
            using (var context = new PsychologyPatientSystemContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
