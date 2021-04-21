using System;
using System.Collections.Generic;
using System.Text;

namespace PsychologyPatientSystem.Core.Utilities.Results
{
  public interface IDataResult<T>
    {
         T Data { get; set; }
        bool Success { get; }
    }
}
