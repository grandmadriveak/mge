using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Common.RestApi.Extension
{
    public static class WebHostBuilderExtension
    {
        public static IWebHostBuilder ConfigDynamicKestrel(this IWebHostBuilder webHostBuilder, IConfiguration configuration, int port)
        {
            webHostBuilder.ConfigureKestrel((options, serverOptions) =>
            {
                serverOptions.ListenAnyIP(port);
            });

            return webHostBuilder;
        }
    }
}
