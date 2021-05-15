using System;
using System.Collections.Generic;
using System.Text;

namespace PsychologyPatientSystem.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base("JsonFileLogger")
        {
        }
    }
}
