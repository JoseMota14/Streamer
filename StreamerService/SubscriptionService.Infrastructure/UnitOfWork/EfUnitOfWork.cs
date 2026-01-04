using SubscriptionService.Application.Abstractions;
using SubscriptionService.Infrastructure.Persistence;

namespace SubscriptionService.Infrastructure.UnitOfWork
{
    public sealed class EfUnitOfWork : IUnitOfWork
    {
        private readonly SubscriptionDbContext _context;

        public EfUnitOfWork(SubscriptionDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync(CancellationToken ct)
        {
            await _context.SaveChangesAsync(ct);
        }
    }

}
