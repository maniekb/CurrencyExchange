using CurrencyExchange.BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.API.Framework
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
                await _logger.LogAsync(context.Request?.Path.Value, context.Request?.Method, context.Response?.StatusCode, DateTime.Now);
            }
        }
    }
}
