using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace PsychologyPatientSystem.Core.Extensions
{
   public  static class ExceptionMiddlewareExtensions
    {
        public static void ConfigrueCustomExceptionMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
