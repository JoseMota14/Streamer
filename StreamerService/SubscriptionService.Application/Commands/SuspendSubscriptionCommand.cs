using SubscriptionService.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Application.Commands
{
    public sealed class SuspendSubscriptionCommand : ICommand
    {
        public Guid UserId { get; }

        public SuspendSubscriptionCommand(Guid userId)
        {
            UserId = userId;
        }
    }

}
