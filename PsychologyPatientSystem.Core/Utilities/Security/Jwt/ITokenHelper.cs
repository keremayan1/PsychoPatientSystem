using System;
using System.Collections.Generic;
using System.Text;
using PsychologyPatientSystem.Core.Entities.Concrete;

namespace PsychologyPatientSystem.Core.Utilities.Security.Jwt
{
   public interface ITokenHelper
   {
       AccessToken CreateAccessToken(User user, List<OperationClaim> operationClaims);
   }
}
