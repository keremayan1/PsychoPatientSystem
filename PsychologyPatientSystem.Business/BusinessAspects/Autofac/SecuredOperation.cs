using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PsychologyPatientSystem.Core.Utilities.Interceptors;
using System.Linq;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using PsychologyPatientSystem.Core.Extensions;
using PsychologyPatientSystem.Core.Utilities.IoC;

namespace PsychologyPatientSystem.Business.BusinessAspects.Autofac
{
  public  class SecuredOperation:MethodInterception
  {
      private string[] _roles;
      private IHttpContextAccessor _httpContextAccessor;

      public SecuredOperation(string roles)
      {
          _roles = roles.Split(",");
          _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
      }

      public override void OnBefore(IInvocation invocation)
      {
          var claims = _httpContextAccessor.HttpContext.User.ClaimRoles();
          foreach (var claim in claims)
          {
              if (claims.Contains(claim))
              {
                  return;
              }
          }

          throw new Exception("Hata");

      }
  }
}
