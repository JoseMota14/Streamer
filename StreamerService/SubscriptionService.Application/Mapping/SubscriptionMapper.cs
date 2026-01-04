using SubscriptionService.Application.DTOs;
using SubscriptionService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Application.Mapping
{
    public static class SubscriptionMapper
    {
        public static SubscriptionDto ToDto(Subscription subscription)
            => new SubscriptionDto
            {
                Id = subscription.Id,
                PlanName = subscription.Plan.Name,
                Price = subscription.Plan.GetPrice().Amount,
                Currency = subscription.Plan.GetPrice().Currency,
                State = subscription.State.Name
            };
    }

}
