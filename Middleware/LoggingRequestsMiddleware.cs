using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace InsuranceApp.Middleware
{
    public class LoggingRequestsMiddleware
    {
        private ILogger<LoggingRequestsMiddleware> _logger;
        private RequestDelegate _next;

        public LoggingRequestsMiddleware(RequestDelegate next, ILogger<LoggingRequestsMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            
            _logger.LogInformation($"[Middleware] - {DateTime.Now}: {context.Request.Host}{context.Request.Path} - StatusCode {context.Response.StatusCode}");
        }
    }
}
