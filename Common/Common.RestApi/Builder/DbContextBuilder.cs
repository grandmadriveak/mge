using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Common.RestApi.Builder
{
    public class DbContextBuilder
    {
        public static Action<DbContextOptionsBuilder> Builder(string serverType, string connectionString, params IInterceptor[] interceptors)
        {
            switch (serverType)
            {
                case "postgre":
                    return (options) =>
                    {
                        options.UseNpgsql(connectionString);
                        options.AddInterceptors(interceptors);
                    };
                case "mssql":
                    //return (options) =>
                    //{
                    //    options.UseSqlServer(connectionString);
                    //    options.AddInterceptors(interceptors);
                    //};
                case "mysql":
                    return null;
                default:
                    return null;
            }
        }
    }
}
