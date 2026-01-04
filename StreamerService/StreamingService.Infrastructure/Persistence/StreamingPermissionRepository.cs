using Microsoft.EntityFrameworkCore;
using StreamingService.Domain.Entities;
using StreamingService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingService.Infrastructure.Persistence
{
    public sealed class StreamingPermissionRepository : IStreamingPermissionRepository
    {
        private readonly StreamingDbContext _context;

        public StreamingPermissionRepository(StreamingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            StreamingPermission permission,
            CancellationToken ct)
        {
            await _context.Permissions.AddAsync(permission, ct);
            await _context.SaveChangesAsync(ct);
        }

        public Task<StreamingPermission?> GetByUserIdAsync(
            Guid userId,
            CancellationToken ct)
        {
            return _context.Permissions
                .FirstOrDefaultAsync(p => p.UserId == userId, ct);
        }
    }
}
