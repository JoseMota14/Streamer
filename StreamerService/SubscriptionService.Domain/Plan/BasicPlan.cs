using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.Plan
{
    public sealed class BasicPlan : SubscriptionPlan
    {
        public override string Name => "Basic";

        public override Money GetPrice() => new (9.99m, "EUR");

        public override bool AllowsOfflineDownload() => false;
        public override int MaxProfiles() => 1;
        public override bool AllowsUltraHD() => false;
    }

}
