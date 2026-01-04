using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingService.Domain.Entities
{
    public sealed class StreamingPermission
    {
        public Guid UserId { get; private set; }
        public bool IsActive { get; private set; }
        public StreamingCapabilities Capabilities { get; private set; }

        private StreamingPermission() { }

        public StreamingPermission(
            Guid userId,
            StreamingCapabilities capabilities)
        {
            UserId = userId;
            Capabilities = capabilities;
            IsActive = true;
        }

        public void Suspend()
        {
            IsActive = false;
        }
    }
}
