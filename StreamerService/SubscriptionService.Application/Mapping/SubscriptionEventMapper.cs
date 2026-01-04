using SharedKernel.IntegrationEvents;
using SubscriptionService.Domain;
using SubscriptionService.Domain.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Application.Mapping
{
    public static class SubscriptionEventMapper
    {
        public static SubscriptionActivatedIntegrationEvent ToIntegrationEvent(
            SubscriptionActivated domainEvent,
            Subscription subscription)
        {
            return new SubscriptionActivatedIntegrationEvent
            {
                UserId = domainEvent.UserId,
                UltraHd = subscription.Plan.AllowsUltraHD(),
                OfflineDownload = subscription.Plan.AllowsOfflineDownload(),
                MaxProfiles = subscription.Plan.MaxProfiles()
            };
        }

    }
}
