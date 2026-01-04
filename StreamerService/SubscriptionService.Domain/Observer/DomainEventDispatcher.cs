using SharedKernel.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace SubscriptionService.Domain.Observer
{
    public sealed class DomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync(IEnumerable<DomainEvent> events, CancellationToken ct)
        {
            foreach (var domainEvent in events)
            {
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
                var handlers = _serviceProvider.GetServices(handlerType);

                foreach (dynamic handler in handlers)
                {
                    await handler.HandleAsync((dynamic)domainEvent, ct);
                }
            }
        }
    }
}
