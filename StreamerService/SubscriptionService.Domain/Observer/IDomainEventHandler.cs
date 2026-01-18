using SharedKernel.Domain;

namespace SubscriptionService.Domain.Observer
{
    public interface IDomainEventHandler<in TEvent> where TEvent : DomainEvent
    {
        Task HandleAsync(TEvent domainEvent, CancellationToken ct);
    }
}
