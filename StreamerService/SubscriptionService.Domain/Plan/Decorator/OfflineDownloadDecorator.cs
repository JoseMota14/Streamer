using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.Plan.Decorator
{
    public sealed class OfflineDownloadDecorator : SubscriptionDecorator
    {
        public OfflineDownloadDecorator(SubscriptionPlan innerPlan)
            : base(innerPlan) { }

        public override string Name => $"{InnerPlan.Name} + Offline";

        public override Money GetPrice()
            => InnerPlan.GetPrice().Add(new Money(2.99m, "EUR"));

        public override bool AllowsOfflineDownload() => true;
        public override int MaxProfiles() => InnerPlan.MaxProfiles();
        public override bool AllowsUltraHD() => InnerPlan.AllowsUltraHD();
    }

}
