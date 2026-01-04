using Microsoft.EntityFrameworkCore;
using SubscriptionService.Application.Interfaces;
using SubscriptionService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Infrastructure.Persistence
{
     public sealed class SubscriptionRepository: ISubscriptionRepository
     {
        private readonly SubscriptionDbContext _context;

        public SubscriptionRepository(SubscriptionDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            Subscription subscription,
            CancellationToken ct)
        {
            await _context.Subscriptions.AddAsync(subscription, ct);
        }

        public async Task<Subscription?> GetByUserIdAsync(
            Guid userId,
            CancellationToken ct)
        {
            return await _context.Subscriptions
                .FirstOrDefaultAsync(x => x.UserId == userId, ct);
        }

        public async Task UpdateAsync(
            Subscription subscription,
            CancellationToken ct)
        {
            _context.Subscriptions.Update(subscription);
        }
    }

}
