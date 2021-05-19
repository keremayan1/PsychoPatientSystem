using System.Collections.Generic;

namespace PsychologyPatientSystem.Core.CrossCuttingConcerns.Logging
{
  public  class LogDetail
    {
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
        
    }
}
