using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Middleware;
namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
