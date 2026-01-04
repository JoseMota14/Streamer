using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingService.Domain.Entities
{
    public sealed class StreamingCapabilities
    {
        public bool UltraHd { get; }
        public bool OfflineDownload { get; }
        public int MaxProfiles { get; }

        public StreamingCapabilities(
            bool ultraHd,
            bool offlineDownload,
            int maxProfiles)
        {
            UltraHd = ultraHd;
            OfflineDownload = offlineDownload;
            MaxProfiles = maxProfiles;
        }
    }
}
