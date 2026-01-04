using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.Plan.Decorator
{
    public abstract class SubscriptionDecorator : SubscriptionPlan
    {
        protected readonly SubscriptionPlan InnerPlan;

        protected SubscriptionDecorator(SubscriptionPlan innerPlan)
        {
            InnerPlan = innerPlan;
        }
    }


}
