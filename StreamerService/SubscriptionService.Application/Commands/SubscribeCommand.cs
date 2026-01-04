using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionService.Application.Abstractions;

namespace SubscriptionService.Application.Commands
{
    public sealed class SubscribeCommand : ICommand
    {
        public Guid UserId { get; }
        public bool UltraHd { get; }
        public bool OfflineDownload { get; }
        public int ExtraProfiles { get; }

        public SubscribeCommand(
            Guid userId,
            bool ultraHd,
            bool offlineDownload,
            int extraProfiles)
        {
            UserId = userId;
            UltraHd = ultraHd;
            OfflineDownload = offlineDownload;
            ExtraProfiles = extraProfiles;
        }
    }
}
