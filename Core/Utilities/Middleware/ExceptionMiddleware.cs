using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Middleware
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {          
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.StatusCode = 400;
            //Bir hata meydana geldiğinde dönecek genel hata mesajı.
            string message = "Internal Server Error";

            IEnumerable<ValidationFailure> validationFailures;

            if (e.GetType() == typeof(ValidationException))
            {
                //Eğer hata ValidationException ise Exceptiondan gelen hata mesajını fırlat Çünkü onu biz yazdık.               
                validationFailures = ((ValidationException)e).Errors;

                 return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = 400,
                    Message = e.Message,
                    Errors= validationFailures

                 }.ToString());//ToString override edilmiştir. JsonSerialize ediyor nesneyi 
            }

            return httpContext.Response.WriteAsync(new ErrorDetailsBase
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());

        }
    }
}
