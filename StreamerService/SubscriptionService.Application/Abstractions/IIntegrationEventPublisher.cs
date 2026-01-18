

namespace SubscriptionService.Application.Abstractions
{
    public interface IIntegrationEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken ct) where TEvent : class;
    }
}
