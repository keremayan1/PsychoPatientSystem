﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PsychologyPatientSystem.Core.Utilities.Security.Jwt
{
   public class TokenOptions
    {
        public string Audince { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration{ get; set; }
        public string SecurityKey { get; set; }

    }
}
