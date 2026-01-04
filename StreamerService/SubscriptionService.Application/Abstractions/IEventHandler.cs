using SharedKernel.Domain;

namespace SubscriptionService.Application.Abstractions
{
    public interface IEventHandler<in TEvent> where TEvent : DomainEvent
    {
        Task HandleAsync(TEvent @event, CancellationToken ct);
    }
}
