using Microsoft.AspNetCore.Http;
using MISA.Core.Entities;
using MISA.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Middlewares
{
    /// <summary>
    /// Middleware bắt lỗi exception
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var response = new ServiceResult();

            response.DevMsg.Add(ex.Message);
            response.UserMsg = Core.Resouces.Message.ExceptionError;
            response.MisaCode = MISACode.EXCEPTION;

            var result = JsonConvert.SerializeObject(response) ;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
