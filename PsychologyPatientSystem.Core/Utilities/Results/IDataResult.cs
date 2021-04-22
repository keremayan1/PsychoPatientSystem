using System;
using System.Collections.Generic;
using System.Text;

namespace PsychologyPatientSystem.Core.Utilities.Results
{
  public interface IDataResult<T>:IResult
    {
         T Data { get; set; }
       
    }
}
