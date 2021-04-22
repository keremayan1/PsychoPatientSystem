using System;
using System.Collections.Generic;
using System.Text;

namespace PsychologyPatientSystem.Core.Utilities.Security.Jwt
{
  public  class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
