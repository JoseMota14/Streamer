using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.State
{
    public interface ISubscriptionState
    {
        string Name { get; }
        void Activate(Subscription subscription);
        void Suspend(Subscription subscription);
        void Expire(Subscription subscription);
    }
}
