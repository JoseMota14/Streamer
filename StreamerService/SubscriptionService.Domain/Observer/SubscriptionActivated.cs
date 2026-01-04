using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.Observer
{
    public sealed class SubscriptionActivated : DomainEvent
    {
        public Guid SubscriptionId { get; }
        public Guid UserId { get; }

        public SubscriptionActivated(Guid subscriptionId, Guid userId)
        {
            SubscriptionId = subscriptionId;
            UserId = userId;
        }
    }

}
