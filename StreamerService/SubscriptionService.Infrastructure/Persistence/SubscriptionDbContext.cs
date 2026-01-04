using Microsoft.EntityFrameworkCore;
using SubscriptionService.Domain;

namespace SubscriptionService.Infrastructure.Persistence
{
    public sealed class SubscriptionDbContext : DbContext
    {
        public DbSet<Subscription> Subscriptions => Set<Subscription>();

        public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(SubscriptionDbContext).Assembly);
        }
    }

}
