using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PsychologyPatientSystem.Business.Abstract;
using PsychologyPatientSystem.Business.BusinessAspects.Autofac;
using PsychologyPatientSystem.Business.Constants;
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

        public IDataResult<List<Patient>> GetAll()
        {
            _patientDal.GetAll();
            return new SuccessDataResult<List<Patient>>("");
        }
        [SecuredOperation("getall,admin")]
        public IDataResult<List<Patient>> GetById(int id)
        {
            _patientDal.GetAll(p => p.Id == id);
            return new SuccessDataResult<List<Patient>>();
        }

        public IResult Add(Patient patient)
        {
            var result = BusinessRules.Run(CheckIfPatientExits(patient.Name));
            if (result != null)
            {
                return result;
            }
            _patientDal.Add(patient);
            return new SuccessResult("Kayıt Eklenmiştir");
        }

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
