using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Application.DTOs
{
    public sealed class SubscriptionDto
    {
        public Guid Id { get; set; }
        public string PlanName { get; set; } = default!;
        public decimal Price { get; set; }
        public string Currency { get; set; } = default!;
        public string State { get; set; } = default!;
    }

}
