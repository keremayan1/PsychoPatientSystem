using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;
using PsychologyPatientSystem.Core.Aspects.Autofac.Exception;
using PsychologyPatientSystem.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace PsychologyPatientSystem.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelectors:IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();

        }
    }
}
