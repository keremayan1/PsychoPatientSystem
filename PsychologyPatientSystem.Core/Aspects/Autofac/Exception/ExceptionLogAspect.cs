using Castle.DynamicProxy;
using PsychologyPatientSystem.Core.CrossCuttingConcerns.Logging;
using PsychologyPatientSystem.Core.CrossCuttingConcerns.Logging.Log4Net;
using PsychologyPatientSystem.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;

namespace PsychologyPatientSystem.Core.Aspects.Autofac.Exception
{
   public class ExceptionLogAspect:MethodInterception
    {
        LoggerServiceBase _loggerServiceBase;

        public ExceptionLogAspect(Type loggerServiceBase)
        {
            if (!typeof(LoggerServiceBase).IsAssignableFrom(loggerServiceBase))
            {
                throw new System.Exception("Hatali Logger ");
            }
            _loggerServiceBase =(LoggerServiceBase) Activator.CreateInstance(loggerServiceBase);
        }

        public override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation, e);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation, System.Exception e)
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
            var logDetailWithException = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters,

            };
            return logDetailWithException;

        }
    }
}
