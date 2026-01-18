using SubscriptionService.Domain.Plan;
using SubscriptionService.Domain.State;
using SharedKernel.Domain;
using SubscriptionService.Domain.Observer;
using SubscriptionService.Domain.Plan.Decorator;

namespace SubscriptionService.Domain
{
    public sealed class Subscription : Entity
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }

        // 👇 Persistidos
        public bool UltraHd { get; private set; }
        public bool OfflineDownload { get; private set; }
        public int MaxProfiles { get; private set; }

        // 👇 Apenas domínio (não mapeado)
        public SubscriptionPlan Plan { get; private set; }

        public ISubscriptionState State { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        private Subscription() { }

        public static Subscription Create(Guid userId, SubscriptionPlan plan)
        {
            var subscription = new Subscription
            {
                UserId = userId,
                UltraHd = plan.AllowsUltraHD(),
                OfflineDownload = plan.AllowsOfflineDownload(),
                MaxProfiles = plan.MaxProfiles(),
                StartDate = DateTime.UtcNow,
                State = new ActiveState()
            };

            // Reconstruir o plano de domínio
            subscription.Plan = RebuildPlan(subscription);

            subscription.AddDomainEvent(
                new SubscriptionActivated(subscription.Id, userId));

            return subscription;
        }

        private static SubscriptionPlan RebuildPlan(Subscription s)
        {
            SubscriptionPlan plan = new BasicPlan();

            if (s.UltraHd)
                plan = new UltraHDDecorator(plan);

            if (s.OfflineDownload)
                plan = new OfflineDownloadDecorator(plan);

           /* if (s.MaxProfiles > 1)
                plan = new SubscriptionDecorator(plan);*/

            return plan;
        }

        public Subscription(Guid userId, SubscriptionPlan plan)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Plan = plan;
            StartDate = DateTime.UtcNow;
            State = new ActiveState();

            AddDomainEvent(new SubscriptionActivated(Id, UserId));
        }

        public void Suspend()
        {
            State.Suspend(this);
            AddDomainEvent(new SubscriptionSuspended(Id));
        }

        public void Expire()
        {
            State.Expire(this);
            EndDate = DateTime.UtcNow;
            AddDomainEvent(new SubscriptionExpired(Id));
        }

        internal void SetState(ISubscriptionState state)
            => State = state;
    }
}
