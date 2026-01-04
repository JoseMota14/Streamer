using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain.Observer
{
    public interface IDomainEventHandler<in TEvent> where TEvent : DomainEvent
    {
        Task HandleAsync(TEvent domainEvent, CancellationToken ct);
    }
}
