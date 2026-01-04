using SubscriptionService.Application.Abstractions;
using SubscriptionService.Application.Interfaces;


namespace SubscriptionService.Application.Commands
{
    public sealed class SuspendSubscriptionCommandHandler: ICommandHandler<SuspendSubscriptionCommand>
    {
        private readonly ISubscriptionRepository _repository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IUnitOfWork _uow;

        public SuspendSubscriptionCommandHandler(
            ISubscriptionRepository repository,
            IEventPublisher eventPublisher,
            IUnitOfWork uow)
        {
            _repository = repository;
            _eventPublisher = eventPublisher;
            _uow = uow;
        }

        public async Task HandleAsync(
            SuspendSubscriptionCommand command,
            CancellationToken ct)
        {
            var subscription =
                await _repository.GetByUserIdAsync(command.UserId, ct)
                ?? throw new InvalidOperationException("Subscription not found");

            subscription.Suspend();

            await _repository.UpdateAsync(subscription, ct);
            await _uow.CommitAsync(ct);

            await _eventPublisher.PublishAsync(
                subscription.DomainEvents,
                ct);

            subscription.ClearDomainEvents();
        }
    }

}
