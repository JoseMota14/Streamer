using SharedKernel.Domain;
using SubscriptionService.Application.Abstractions;
using SubscriptionService.Application.Interfaces;
using SubscriptionService.Application.Mapping;
using SubscriptionService.Domain;
using SubscriptionService.Domain.Observer;
using SubscriptionService.Domain.Plan;
using SubscriptionService.Domain.Plan.Decorator;
using System;

namespace SubscriptionService.Application.Commands
{
    public sealed class SubscribeCommandHandler : ICommandHandler<SubscribeCommand>
    {
        private readonly ISubscriptionRepository _repository;
        private readonly IPlanFactory _planFactory;
        private readonly IEventPublisher _eventPublisher;
        private readonly IUnitOfWork _uow;
        private readonly DomainEventDispatcher _dispatcher;

        public SubscribeCommandHandler(
            ISubscriptionRepository repository,
            IPlanFactory planFactory,
            IEventPublisher eventPublisher,
            IUnitOfWork uow,
            DomainEventDispatcher dispatcher)
        {
            _repository = repository;
            _planFactory = planFactory;
            _eventPublisher = eventPublisher;
            _uow = uow;
            _dispatcher = dispatcher;
        }

        public async Task HandleAsync(SubscribeCommand command, CancellationToken ct)
        {
            SubscriptionPlan plan = new BasicPlan();
            if (command.UltraHd) plan = new UltraHDDecorator(plan);
            if (command.OfflineDownload) plan = new OfflineDownloadDecorator(plan);

            var subscription = Subscription.Create(command.UserId, plan);

            await _repository.AddAsync(subscription, ct);
            await _uow.CommitAsync(ct);

            //Observer interno
            await _dispatcher.DispatchAsync(subscription.DomainEvents, ct);

            // 🔹 Publicar DomainEvent para fora
            await _eventPublisher.PublishAsync(subscription.DomainEvents, ct);

            subscription.ClearDomainEvents();
        }
    }
}
