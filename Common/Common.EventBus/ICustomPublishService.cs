namespace Common.EventBus.EventBusService
{
    public interface ICustomPublishService
    {
        Task PublishEventAsync<T>(string routingKey, T value, Dictionary<string, string>? headers = null);
    }
}
