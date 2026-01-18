using SharedKernel.Domain;

namespace SubscriptionService.Application.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishAsync(IEnumerable<DomainEvent> events, CancellationToken ct);
    }
}
