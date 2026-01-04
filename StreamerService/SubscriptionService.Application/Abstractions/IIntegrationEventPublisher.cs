using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Application.Abstractions
{
    public interface IIntegrationEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken ct) where TEvent : class;
    }
}
