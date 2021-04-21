using PsychologyPatientSystem.Core.DataAccess.EntityFramework;
using PsychologyPatientSystem.DataAccess.Abstract;
using PsychologyPatientSystem.DataAccess.Concrete.EntityFramework.MSSQL.Context;
using PsychologyPatientSystem.Entities.Concrete;

namespace PsychologyPatientSystem.DataAccess.Concrete.EntityFramework.MSSQL
{
   public class EfPatientDal:EfEntityRepository<Patient,PsychologyPatientSystemContext>,IPatientDal
    {
    }
}
