using Microsoft.AspNetCore.Mvc;

namespace SubscriptionService.API.Contracts
{
    public sealed class SubscribeRequest
    {
        public Guid UserId { get; set; }
        public bool UltraHd { get; set; }
        public bool OfflineDownload { get; set; }
        public int ExtraProfiles { get; set; }
    }

}
