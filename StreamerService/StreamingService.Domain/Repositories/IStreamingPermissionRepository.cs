using StreamingService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingService.Domain.Repositories
{
    public interface IStreamingPermissionRepository
    {
        Task<StreamingPermission?> GetByUserIdAsync(Guid userId, CancellationToken ct);
        Task AddAsync(StreamingPermission permission, CancellationToken ct);
    }
}
