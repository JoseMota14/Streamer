using SubscriptionService.Domain.Plan;
using SubscriptionService.Domain.State;
using SharedKernel.Domain;
using SubscriptionService.Domain.Observer;

namespace SubscriptionService.Domain
{
    public sealed class Subscription : Entity
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public SubscriptionPlan Plan { get; private set; }
        public ISubscriptionState State { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        private readonly List<DomainEvent> _domainEvents = new();
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Subscription() { }

        public static Subscription Create(Guid userId, SubscriptionPlan plan)
        {
            var subscription = new Subscription
            {
                UserId = userId,
                Plan = plan,
                StartDate = DateTime.UtcNow,
                State = new ActiveState()
        };

            subscription.AddDomainEvent(new SubscriptionActivated(subscription.Id, userId));
            return subscription;
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
