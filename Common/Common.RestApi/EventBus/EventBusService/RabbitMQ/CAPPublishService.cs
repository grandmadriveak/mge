using Common.RestApi.Constants;
using Common.RestApi.Extension;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;

namespace Common.EventBus.EventBusService.RabbitMQ
{
    public class CAPPublishService(ICapPublisher capPublisher, IHttpContextAccessor httpContextAccessor) : ICustomPublishService
    {
        public async Task PublishEventAsync<T>(string routingKey, T value, Dictionary<string, string>? headers = null)
        {
            if (headers == null || headers.Count == 0)
            {
                var collerationId = httpContextAccessor.HttpContext.CurrentCollerationId();
                headers.Add(CommonConstant.CollerationId, collerationId.ToString());

                //TODO: support multi-tenancy

                //TODO: add authorize token hear
            }
            await capPublisher.PublishAsync(routingKey, value, headers: headers);
        }
    }
}
