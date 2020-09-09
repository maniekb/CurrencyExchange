using CurrencyExchange.BusinessLayer.Models;
using CurrencyExchange.BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CurrencyExchange.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingService _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILoggingService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                await _logger.LogAsync(RequestType.ApiRequest, context.Request?.Path.Value, context.Request?.Method, context.Response?.StatusCode, DateTime.Now);
            }
        }
    }
}
