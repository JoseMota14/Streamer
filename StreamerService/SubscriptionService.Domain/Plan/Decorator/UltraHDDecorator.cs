using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.Plan.Decorator
{
    public sealed class UltraHDDecorator : SubscriptionDecorator
    {
        public UltraHDDecorator(SubscriptionPlan innerPlan)
            : base(innerPlan) { }

        public override string Name => $"{InnerPlan.Name} + UltraHD";

        public override Money GetPrice()
            => InnerPlan.GetPrice().Add(new Money(4.99m, "EUR"));

        public override bool AllowsOfflineDownload()
            => InnerPlan.AllowsOfflineDownload();

        public override int MaxProfiles()
            => InnerPlan.MaxProfiles();

        public override bool AllowsUltraHD() => true;
    }

}
