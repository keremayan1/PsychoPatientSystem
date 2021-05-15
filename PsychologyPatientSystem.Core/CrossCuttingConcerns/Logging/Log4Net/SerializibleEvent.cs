using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PsychologyPatientSystem.Core.CrossCuttingConcerns.Logging.Log4Net
{
   [Serializable]
  public  class SerializibleLogEvent
    {
        LoggingEvent _loggingEvent;

        public SerializibleLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public object Message => _loggingEvent.MessageObject;
    }
}
