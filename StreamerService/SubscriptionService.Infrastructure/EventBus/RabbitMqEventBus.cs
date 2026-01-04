using RabbitMQ.Client;
using SharedKernel.Domain;
using SubscriptionService.Application.Interfaces;
using System.Text.Json;

namespace SubscriptionService.Infrastructure.EventBus
{
    public sealed class RabbitMqEventBus : IEventPublisher
    {
        private readonly IConnection _connection;

        public RabbitMqEventBus(IConnection connection)
        {
            _connection = connection;
        }

        public Task PublishAsync(
            IEnumerable<DomainEvent> events,
            CancellationToken ct)
        {
            using var channel = _connection.CreateModel();

            foreach (var domainEvent in events)
            {
                var body = JsonSerializer.SerializeToUtf8Bytes(domainEvent);

                channel.BasicPublish(
                    exchange: "subscription.events",
                    routingKey: domainEvent.GetType().Name,
                    basicProperties: null,
                    body: body);
            }

            return Task.CompletedTask;
        }
    }

}
