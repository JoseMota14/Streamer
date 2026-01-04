using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.IntegrationEvents
{
    public sealed class SubscriptionSuspendedIntegrationEvent
    {
        public Guid UserId { get; init; }
    }
}
