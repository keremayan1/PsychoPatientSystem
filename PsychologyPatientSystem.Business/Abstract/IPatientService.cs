using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PsychologyPatientSystem.Core.Utilities.Results;
using PsychologyPatientSystem.Entities.Concrete;

namespace PsychologyPatientSystem.Business.Abstract
{
    public interface IPatientService
    {
        IDataResult<List<Patient>> GetAll();
        IDataResult<List<Patient>> GetById(int id);
        IResult Add(Patient patient);
        IResult Update(Patient patient);
        IResult Delete(Patient patient);
        IResult TransactionOperation(Patient patient);
        Task<IResult> AddAsync(Patient patient);

    }
}
