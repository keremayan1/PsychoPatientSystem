using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using PsychologyPatientSystem.Core.Utilities.Interceptors;
using PsychologyPatientSystem.Core.Utilities.IoC;

namespace PsychologyPatientSystem.Core.Aspects.Autofac.Performance
{
   public class PerformanceScopeAspect:MethodInterception
   {
       private int _interval;
       private Stopwatch _stopwatch;

       public PerformanceScopeAspect(int interval)
       {
           _interval = interval;
           _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
       }

       public override void OnBefore(IInvocation invocation)
       {
           _stopwatch.Start();
       }

       public override void OnAfter(IInvocation invocation)
       {
           if (_stopwatch.Elapsed.TotalSeconds>_interval)
           {
               Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
           }
           _stopwatch.Reset();
       }
   }
}
