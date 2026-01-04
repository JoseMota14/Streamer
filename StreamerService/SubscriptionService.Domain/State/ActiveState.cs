using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.State
{
    public sealed class ActiveState : ISubscriptionState
    {
        public string Name => "Active";

        public void Activate(Subscription subscription) { }

        public void Suspend(Subscription subscription)
            => subscription.SetState(new SuspendedState());

        public void Expire(Subscription subscription)
            => subscription.SetState(new ExpiredState());
    }
}
