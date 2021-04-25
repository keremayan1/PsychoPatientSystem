using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PsychologyPatientSystem.Core.Utilities.IoC;

namespace PsychologyPatientSystem.Core.Extensions
{
  public  static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection collection,params ICoreModule[] modules)

        {
            foreach (var coreModule in modules)
            {
                coreModule.Load(collection);
            }

            return ServiceTool.Create(collection);
        }
        
    } 
}
