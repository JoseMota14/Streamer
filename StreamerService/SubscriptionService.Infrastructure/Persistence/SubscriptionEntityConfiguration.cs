using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SubscriptionService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Infrastructure.Persistence
{
    public sealed class SubscriptionEntityConfiguration
        : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId).IsRequired();

            builder.OwnsOne(x => x.Plan, plan =>
            {
                plan.Ignore(p => p.Name);
            });

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.State);
        }
    }

}
