using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.State
{
    public sealed class ExpiredState : ISubscriptionState
    {
        public string Name => "Expired";

        public void Activate(Subscription subscription)
            => throw new InvalidOperationException("Expired subscription cannot be reactivated");

        public void Suspend(Subscription subscription) { }

        public void Expire(Subscription subscription) { }
    }

}
