using Common.RestApi.Constants;
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

        public static Guid CurrentCollerationId(this HttpContext httpContent)
        {
            httpContent.Request.Headers.TryGetValue(CommonConstant.CollerationId, out var collerationId);
            if (string.IsNullOrEmpty(collerationId))
            {
                return Guid.Empty;
            }
            return new Guid(collerationId);
        }
    }
}
