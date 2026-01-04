using SharedKernel.Domain;
using SubscriptionService.Application.Interfaces;

namespace SubscriptionService.Infrastructure.EventBus
{
    public sealed class EventDispatcher
    {
        private readonly IEventPublisher _eventPublisher;

        public EventDispatcher(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public Task DispatchAsync(
            IEnumerable<DomainEvent> events,
            CancellationToken ct)
        {
            return _eventPublisher.PublishAsync(events, ct);
        }
    }

}
