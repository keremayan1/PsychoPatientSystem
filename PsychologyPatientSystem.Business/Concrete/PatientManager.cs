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
using PsychologyPatientSystem.Core.Aspects.Autofac.Performance;
using PsychologyPatientSystem.Core.Aspects.Autofac.Transaction;
using PsychologyPatientSystem.Core.Aspects.Autofac.Validation;
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



       
        [CacheAspect]
        
        public IDataResult<List<Patient>> GetAll()
        {
            
            _patientDal.GetAll();
            return new SuccessDataResult<List<Patient>>("123");
        }
        
        public IDataResult<List<Patient>> GetById(int id)
        {
            _patientDal.GetAll(p => p.Id == id);
            return new SuccessDataResult<List<Patient>>();
        }
        [PerformanceScopeAspect(5)]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IPatientService.Get")]
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
            return new SuccessResult("Kayıt Eklenmiştir");
        }
        [ValidationAspect(typeof(PatientValidator))]
        public IResult Update(Patient patient)
        {
            _patientDal.Update(patient);
            return new SuccessResult();

        }

        public IResult Delete(Patient patient)
        {
            _patientDal.Delete(patient);
            return new SuccessResult();
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
                return new ErrorResult(Messages.hastaaynıolamaz);
            }

            return new SuccessResult();
        }
    }
}
