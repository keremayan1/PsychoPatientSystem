using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PsychologyPatientSystem.Business.Abstract;
using PsychologyPatientSystem.Business.BusinessAspects.Autofac;
using PsychologyPatientSystem.Business.Constants;
using PsychologyPatientSystem.Business.ValidationRules.FluentValidation;
using PsychologyPatientSystem.Core.Aspects.Autofac.Caching;
using PsychologyPatientSystem.Core.Aspects.Autofac.Logging;
using PsychologyPatientSystem.Core.Aspects.Autofac.Performance;
using PsychologyPatientSystem.Core.Aspects.Autofac.Transaction;
using PsychologyPatientSystem.Core.Aspects.Autofac.Validation;
using PsychologyPatientSystem.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using PsychologyPatientSystem.Core.Utilities.Business;

using PsychologyPatientSystem.Core.Utilities.Results;
using PsychologyPatientSystem.DataAccess.Abstract;
using PsychologyPatientSystem.Entities.Concrete;

namespace PsychologyPatientSystem.Business.Concrete
{
    public class PatientManager : IPatientService
    {
        private IPatientDal _patientDal;

        public PatientManager(IPatientDal patientDal)
        {
            _patientDal = patientDal;
        }



        [SecuredOperation("admin,user")]
        [CacheAspect]
        public IDataResult<List<Patient>> GetAll()
        {
            return new SuccessDataResult<List<Patient>>( _patientDal.GetAll(),Messages.PatientsGetAll);
        }
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Patient>> GetById(int id)
        {
            return new SuccessDataResult<List<Patient>>(_patientDal.GetAll(p => p.Id == id),Messages.PatientsGetById);
        }
        [PerformanceScopeAspect(5)]
      [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IPatientService.Get")]
        [LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(PatientValidator))]

       
        public IResult Add(Patient patient)
        {
         //   Thread.Sleep(5000);
            var result = BusinessRules.Run(CheckIfPatientExits(patient.Name));
            if (result != null)
            {
                return result;
            }
            _patientDal.Add(patient);
            return new SuccessResult(Messages.AddedPatients);
        }
        [ValidationAspect(typeof(PatientValidator))]
        public IResult Update(Patient patient)
        {
            var result = BusinessRules.Run(CheckIfPatientExits(patient.Name));
            if (result!=null)
            {
                return result;
            }
            _patientDal.Update(patient);
            return new SuccessResult(Messages.UpdatedPatients);

        }

        public IResult Delete(Patient patient)
        {
            _patientDal.Delete(patient);
            return new SuccessResult(Messages.DeletedPatients);
        }
        [TransactionScopeAspect]
        public IResult TransactionOperation(Patient patient)
        {
            _patientDal.Update(patient);
            _patientDal.Add(patient);
            return new SuccessResult();
        }

        private IResult CheckIfPatientExits(string name)
        {
            var result = _patientDal.GetAll(p => p.Name == name).Any();
            if (result)
            {
                return new ErrorResult(Messages.PatientsAlreadyExits);
            }

            return new SuccessResult();
        }
    }
}
