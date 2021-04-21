using System;
using System.Collections.Generic;
using System.Text;
using PsychologyPatientSystem.Core.Entities;

namespace PsychologyPatientSystem.Entities.Concrete
{
  public  class Patient:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
