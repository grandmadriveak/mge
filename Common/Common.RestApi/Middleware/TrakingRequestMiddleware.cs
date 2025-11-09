using Common.RestApi.Constants;
using Microsoft.AspNetCore.Http;
using Omni.Services.Logging;

namespace Common.RestApi.Middleware
{
    public class TrakingRequestMiddleware
    {
        private readonly Seriloger _logger = Seriloger.GetInstant(typeof(RuntimeContextMiddleware));
        private readonly RequestDelegate _next;
        public TrakingRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.Info("Started tracking request");
            if (!context.Request.Headers.ContainsKey(CommonConstant.CollerationId))
            {
                context.Request.Headers.Add(CommonConstant.CollerationId, Guid.NewGuid().ToString());
            }
            _logger.Info("Finished tracking request");
            await _next(context);
        }
    }
}
