using Common.RestApi.Constants;
using DotNetCore.CAP;

namespace Shipping.Services.EventHandler
{
    [CapSubscribe(RabbitMQConstants.RoutingKey.Demo, Group = "myqueue")]
    public class DemoEventHandler : ICapSubscribe
    {
    }
}
