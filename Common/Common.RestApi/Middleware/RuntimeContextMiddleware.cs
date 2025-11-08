using Common.RestApi.Extension;
using Microsoft.AspNetCore.Http;
using Omni.Services.Logging;

namespace Common.RestApi.Middleware
{
    public class RuntimeContextMiddleware
    {
        private readonly Seriloger _logger = Seriloger.GetInstant(typeof(RuntimeContextMiddleware));
        private readonly ITenantService _tenantService;
        private readonly RequestDelegate _next;
        public RuntimeContextMiddleware(RequestDelegate next, ITenantService tenantService)
        {
            _next = next;
            _tenantService = tenantService;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.Info("Started get and update tenantId");
            var tenantId = context.CurrentTenantId();
            _tenantService.UpdateTenantConfig(tenantId);
            _logger.Info("Finished update tenantId");
            await _next(context);
        }
    }
}
