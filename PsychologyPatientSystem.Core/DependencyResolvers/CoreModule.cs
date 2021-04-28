using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PsychologyPatientSystem.Core.CrossCuttingConcerns.Caching;
using PsychologyPatientSystem.Core.CrossCuttingConcerns.Caching.Microsoft;
using PsychologyPatientSystem.Core.Utilities.IoC;

namespace PsychologyPatientSystem.Core.DependencyResolvers
{
   public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
