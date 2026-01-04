using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionService.Domain;

namespace SubscriptionService.Application.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task AddAsync(Subscription subscription, CancellationToken ct);
        Task<Subscription?> GetByUserIdAsync(Guid userId, CancellationToken ct);
        Task UpdateAsync(Subscription subscription, CancellationToken ct);
    }

}
