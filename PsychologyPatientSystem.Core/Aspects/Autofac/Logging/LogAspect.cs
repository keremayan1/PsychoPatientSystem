using PsychologyPatientSystem.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using PsychologyPatientSystem.Core.CrossCuttingConcerns.Logging;
using PsychologyPatientSystem.Core.CrossCuttingConcerns.Logging.Log4Net;

namespace PsychologyPatientSystem.Core.Aspects.Autofac.Logging
{
   public class LogAspect:MethodInterception
   {
       private LoggerServiceBase _loggerServiceBase;

       public LogAspect(Type loggerService)
       {
           //if (loggerService.BaseType!=typeof(LoggerServiceBase))
           //{
           //    throw new Exception("Hatalı Logger Servisi");
           //}

           if (!typeof(LoggerServiceBase).IsAssignableFrom(loggerService))
           {
               throw new Exception("Hatalı Logger Servisi");
           }

           _loggerServiceBase = (LoggerServiceBase) Activator.CreateInstance(loggerService);
       }

       public override void OnBefore(IInvocation invocation)
       {
           _loggerServiceBase.Info(LogDetail(invocation));
       }

       private LogDetail LogDetail(IInvocation invocation)
       {

            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }
             var logDetail = new LogDetail // varlık sınıfı olduğundan rahatlıkla newleyebiliriz
           {
               MethodName = invocation.Method.Name,
               LogParameters = logParameters
           };
           return logDetail;


           //var logParameters = invocation.Arguments.Select(x => new LogParameter
           //{
           //    Value = x,
           //    Type = x.GetType().Name
           //}).ToList();
          
       }
   }
}
