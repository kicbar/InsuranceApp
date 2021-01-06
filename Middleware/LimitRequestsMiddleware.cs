using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace InsuranceApp.Middleware
{
    public class LimitRequestsMiddleware : IMiddleware
    {
        private ILogger<LimitRequestsMiddleware> _logger;

        public LimitRequestsMiddleware(ILogger<LimitRequestsMiddleware> logger)
        {
            _logger = logger;
        }

        private int counter;
        private int limit = 10;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (counter >= limit)
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            else
            {
                counter++;
                try
                {
                    _logger.LogInformation($"[Middleware] - BEGIN REQUEST - counter: {counter}");
                    await next(context);
                    _logger.LogInformation($"[Middleware] - END   REQUEST - counter: {counter}");
                }
                finally
                {
                    counter--;
                }
            }
        }
    }
}
