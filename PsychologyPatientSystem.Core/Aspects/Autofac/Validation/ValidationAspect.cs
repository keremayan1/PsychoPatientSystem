using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;
using FluentValidation;
using PsychologyPatientSystem.Core.CrossCuttingConcerns.Validation.FluentValidation;
using PsychologyPatientSystem.Core.Utilities.Interceptors;

namespace PsychologyPatientSystem.Core.Aspects.Autofac.Validation
{
  public  class ValidationAspect:MethodInterception
  {
      private Type _type;

      public ValidationAspect(Type type)
      {
          if (!typeof(IValidator).IsAssignableFrom(type))
          {
              throw new Exception("Wrong Valid Type");
          }
          _type = type;
      }

      public override void OnBefore(IInvocation invocation)
      {
          var validator = (IValidator)Activator.CreateInstance(_type);
          var entityType = _type.BaseType.GetGenericArguments()[0];
          var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
          foreach (var entity in entities)
          {
              ValidationTool.Validator(validator,entity);
          }
      }
  }
}
