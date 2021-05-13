using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PsychologyPatientSystem.Entities.Concrete;

namespace PsychologyPatientSystem.Business.ValidationRules.FluentValidation
{
   public class PatientValidator:AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.Name).MaximumLength(64);
           // RuleFor(p => p.Age).GreaterThan(0);
        }
    }
}
