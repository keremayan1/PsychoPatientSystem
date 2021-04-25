using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace PsychologyPatientSystem.Core.Utilities.IoC
{
   public interface ICoreModule
   {
       void Load(IServiceCollection serviceCollection);
   }
}
