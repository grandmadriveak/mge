using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EventBus.EventBusService
{
    public interface ICustomPublishService
    {
        Task PublishEventAsync<T>(string routingKey, T value, Dictionary<string, string>? headers = null);
    }
}
