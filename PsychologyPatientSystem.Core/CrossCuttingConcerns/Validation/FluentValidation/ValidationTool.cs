using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace PsychologyPatientSystem.Core.CrossCuttingConcerns.Validation.FluentValidation
{
  public  class ValidationTool
    {
        public static void Validator(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
