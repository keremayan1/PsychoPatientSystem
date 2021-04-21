using System;
using System.Collections.Generic;
using System.Text;
using PsychologyPatientSystem.Core.DataAccess;
using PsychologyPatientSystem.Entities.Concrete;

namespace PsychologyPatientSystem.DataAccess.Abstract
{
   public interface IPatientDal:IEntityRepository<Patient>
    {
    }
}
