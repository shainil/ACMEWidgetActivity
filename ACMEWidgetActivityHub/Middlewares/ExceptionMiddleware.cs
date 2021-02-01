using ACMEWidgetActivityDL.Common;
using ACMEWidgetActivityDL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ACMEWidgetActivityHub.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate _next)
        {
            this._next = _next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //Log the error in exception file
                LogData.LogException(ex.Message);

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        //Handles error globally.
        //Any unhandles error in application will come to here. 
        //Fomate the error using error detail class
        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;          

            ErrorDetails error = new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
            };           

            return context.Response.WriteAsync(error.ToString());

        }
       
    }

}
