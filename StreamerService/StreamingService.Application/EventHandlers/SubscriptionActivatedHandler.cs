using SharedKernel.IntegrationEvents;
using StreamingService.Domain.Entities;
using StreamingService.Domain.Repositories;
using SubscriptionService.Domain.Observer;

namespace StreamingService.Application.EventHandlers
{
    public sealed class SubscriptionActivatedHandler : IDomainEventHandler<SubscriptionActivated>
    {
        private readonly IStreamingPermissionRepository _repository;

        public SubscriptionActivatedHandler(IStreamingPermissionRepository repository)
        {
            _repository = repository;
        }

        public Task HandleAsync(
        SubscriptionActivated domainEvent,
        CancellationToken ct)
        {
            Console.WriteLine(
                $"[DOMAIN] SubscriptionActivated for User {domainEvent.UserId}");

            return Task.CompletedTask;
        }
    }
}
