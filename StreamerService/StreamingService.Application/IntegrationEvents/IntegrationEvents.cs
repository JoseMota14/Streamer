using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingService.Application.IntegrationEvents
{
    public sealed class SubscriptionActivatedIntegrationEvent
    {
        public Guid UserId { get; init; }
        public bool UltraHd { get; init; }
        public bool OfflineDownload { get; init; }
        public int MaxProfiles { get; init; }
    }
}
