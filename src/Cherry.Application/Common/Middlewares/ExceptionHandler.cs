using Cherry.Application.Common.Exceptions;
using Cherry.Application.Common.Structures;
using Cherry.Domain.Common;
using Cherry.Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Cherry.Application.Common.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly CherryDbContext _context;

        public ExceptionHandler(RequestDelegate next, CherryDbContext context)
        {
            _next = next;
            _context = context;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _context.Logs.Add(new Log { ExceptionMessage = ex.Message });
                await _context.SaveChangesAsync();
                //TODO: log exception to file and db
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            string exceptionMessage;

            if (exception is AppBaseException)
            {
                AppBaseException appBaseException = exception as AppBaseException;

                context.Response.StatusCode = 400;
                exceptionMessage = appBaseException.Message;
            }
            else if (exception is AuthException)
            {
                context.Response.StatusCode = 401;
                exceptionMessage = "UnAuthenticated";
            }
            else
            {
                context.Response.StatusCode = 500;
                exceptionMessage = "Internal Server Error";
            }

            var response = new ResponseStructure()
            {
                Message = exceptionMessage
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}