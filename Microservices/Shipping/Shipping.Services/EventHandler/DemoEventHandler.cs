using Common.RestApi.Constants;
using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.EventHandler
{
    [CapSubscribe(RabbitMQConstants.RoutingKey.Demo, Group = "myqueue")]
    public class DemoEventHandler : ICapSubscribe
    {
    }
}
