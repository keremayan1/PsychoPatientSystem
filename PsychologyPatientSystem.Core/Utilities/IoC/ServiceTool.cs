using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace PsychologyPatientSystem.Core.Utilities.IoC
{
   public class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get;private set; }

        public static IServiceCollection Create(IServiceCollection collection)
        {
            ServiceProvider = collection.BuildServiceProvider();
            return collection;
        }
    }
}
