using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.Observer
{
    public sealed class SubscriptionExpired : DomainEvent
    {
        public Guid SubscriptionId { get; }

        public SubscriptionExpired(Guid subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }

}
