using SubscriptionService.Domain.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Application.Interfaces
{
    public interface IPlanFactory
    {
        SubscriptionPlan Create(
            bool ultraHd,
            bool offlineDownload,
            int extraProfiles);
    }
}
