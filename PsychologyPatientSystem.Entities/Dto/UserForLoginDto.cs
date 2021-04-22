using System;
using System.Collections.Generic;
using System.Text;
using PsychologyPatientSystem.Core.Entities;

namespace PsychologyPatientSystem.Entities.Dto
{
   public class UserForLoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
