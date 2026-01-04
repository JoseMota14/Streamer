using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingService.Application.EventHandlers
{
    public interface IIntegrationEventHandler<in TEvent>
    {
        Task HandleAsync(TEvent @event, CancellationToken ct);
    }
}
