using SharedKernel.Domain;
using SubscriptionService.Domain.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionService.Domain
{
    public sealed class ConsoleLoggingEventHandler<TEvent> : IDomainEventHandler<TEvent> where TEvent : DomainEvent
    {
        public Task HandleAsync(TEvent domainEvent, CancellationToken ct)
        {
            Console.WriteLine($"[ConsoleLoggingEventHandler] Evento recebido: {domainEvent.GetType().Name} " +
                              $"- OccurredOn: {domainEvent.OccurredOn}");
            return Task.CompletedTask;
        }
    }
}
