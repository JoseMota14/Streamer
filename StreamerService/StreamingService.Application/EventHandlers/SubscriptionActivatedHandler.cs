using SharedKernel.IntegrationEvents;
using StreamingService.Domain.Entities;
using StreamingService.Domain.Repositories;

namespace StreamingService.Application.EventHandlers
{
    public sealed class SubscriptionActivatedHandler : IIntegrationEventHandler<SubscriptionActivatedIntegrationEvent>
    {
        private readonly IStreamingPermissionRepository _repository;

        public SubscriptionActivatedHandler(IStreamingPermissionRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(SubscriptionActivatedIntegrationEvent @event, CancellationToken ct)
        {
            // Exemplo: criar permissões de streaming para o utilizador
            var permission = new  StreamingPermission(
                @event.UserId,
                new StreamingCapabilities(@event.UltraHd, @event.OfflineDownload, @event.MaxProfiles)
            );

            await _repository.AddAsync(permission, ct);

            Console.WriteLine($"[StreamingService] Permissões de streaming criadas para UserId: {@event.UserId}");
        }
    }
}
