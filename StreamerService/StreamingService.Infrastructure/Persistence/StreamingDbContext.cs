using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StreamingService.Domain.Entities;

namespace StreamingService.Infrastructure.Persistence
{
    public sealed class StreamingDbContext : DbContext
    {
        public DbSet<StreamingPermission> Permissions => Set<StreamingPermission>();

        public StreamingDbContext(DbContextOptions<StreamingDbContext> options)
            : base(options)
        {
        }
    }

}
