using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.State
{
    public sealed class SuspendedState : ISubscriptionState
    {
        public string Name => "Suspended";

        public void Activate(Subscription subscription)
            => subscription.SetState(new ActiveState());

        public void Suspend(Subscription subscription) { }

        public void Expire(Subscription subscription)
            => subscription.SetState(new ExpiredState());
    }

}
