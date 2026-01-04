using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.Plan
{
    public abstract class SubscriptionPlan
    {
        public abstract string Name { get; }
        public abstract Money GetPrice();
        public abstract bool AllowsOfflineDownload();
        public abstract int MaxProfiles();
        public abstract bool AllowsUltraHD();
    }

}
