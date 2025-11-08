using Common.CoreEntity.Enums;

namespace Common.RestApi
{
    public class RuntimeContext
    {
        public static CommonConfig CommonConfig { get; set; }
        public static TenantInfo TenantInfo { get; set; }
        public static CurrentUserInfo CurrentUserInfo { get; set; }
    }

    public class CommonConfig
    {
        public SqlServiceConfig SqlServerConfig { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public SSLConfig SSLConfig { get; set; }
        public RedisCacheConfig RedisCacheConfig { get; set; }
        public RabbitMQConfig RabbitMQConfig { get; set; }
    }

    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecurityKey { get; set; }
    }

    public class SqlServiceConfig
    {
        public string ServerType { get; set; }
        public string ConnectionString { get; set; }
        public string AuditConnectionString { get; set; }
    }

    public class SSLConfig
    {
        public string Path { get; set; }
        public string Password { get; set; }
    }

    public class RedisCacheConfig
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
    }

    public class TenantInfo
    {
        public Guid TenantId { get; set; }
        public string ConnectionString { get; set; }
        public string AuditConnectionString { get; set; }
    }

    public class RabbitMQConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class CurrentUserInfo
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
