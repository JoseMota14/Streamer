using SubscriptionService.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionService.Application.DTOs;

namespace SubscriptionService.Application.Queries
{
    public sealed class GetSubscriptionQuery: IQuery<SubscriptionDto>
    {
        public Guid UserId { get; }

        public GetSubscriptionQuery(Guid userId)
        {
            UserId = userId;
        }
    }

}
