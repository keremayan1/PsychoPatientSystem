using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using PsychologyPatientSystem.Core.CrossCuttingConcerns.Caching;
using PsychologyPatientSystem.Core.Utilities.Interceptors;
using PsychologyPatientSystem.Core.Utilities.IoC;

namespace PsychologyPatientSystem.Core.Aspects.Autofac.Caching
{
   public class CacheRemoveAspect:MethodInterception
   {
       private string _removeByPattern;
       private ICacheManager _cacheManager;

       public CacheRemoveAspect(string removeByPattern )
       {
           _removeByPattern = removeByPattern;
           _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
       }

       public override void OnSuccess(IInvocation invocation)
       {
           _cacheManager.RemoveByPattern(_removeByPattern);
       }
   }
}
