using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.Observer
{
    public sealed class SubscriptionSuspended : DomainEvent
    {
        public Guid SubscriptionId { get; }

        public SubscriptionSuspended(Guid subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }

}
