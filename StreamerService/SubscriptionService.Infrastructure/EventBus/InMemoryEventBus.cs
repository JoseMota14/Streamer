using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Domain;
using SubscriptionService.Application.Abstractions;
using SubscriptionService.Application.Interfaces;

namespace SubscriptionService.Infrastructure.EventBus
{
    public sealed class InMemoryEventBus : IEventPublisher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryEventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task PublishAsync(
            IEnumerable<DomainEvent> events,
            CancellationToken ct)
        {
            foreach (var domainEvent in events)
            {
                var handlers = _serviceProvider
                    .GetServices<IEventHandler<DomainEvent>>();

                foreach (var handler in handlers)
                {
                    await handler.HandleAsync(domainEvent, ct);
                }
            }
        }
    }

}
