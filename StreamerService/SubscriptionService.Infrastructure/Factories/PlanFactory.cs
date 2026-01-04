using SubscriptionService.Application.Interfaces;
using SubscriptionService.Domain.Plan.Decorator;
using SubscriptionService.Domain.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Infrastructure.Factories
{
    public sealed class PlanFactory : IPlanFactory
    {
        public SubscriptionPlan Create(
            bool ultraHd,
            bool offlineDownload,
            int extraProfiles)
        {
            SubscriptionPlan plan = new BasicPlan();

            if (ultraHd)
                plan = new UltraHDDecorator(plan);

            if (offlineDownload)
                plan = new OfflineDownloadDecorator(plan);

            return plan;
        }
    }

}
