using Microsoft.AspNetCore.Http;

namespace Common.RestApi.Extension
{
    public static class HttpContextExtension
    {
        public static Guid CurrentTenantId(this HttpContext httpContext)
        {
            return Guid.Empty;
        }

        public static Guid CurrentUserId(this HttpContext httpContent)
        {
            return Guid.Empty;
        }
    }
}
