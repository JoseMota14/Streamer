using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Application.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishAsync(IEnumerable<DomainEvent> events, CancellationToken ct);
    }

}
