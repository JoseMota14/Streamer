using RabbitMQ.Client;
using SubscriptionService.Application.Abstractions;
using System.Text;
using System.Text.Json;

namespace SubscriptionService.Infrastructure.EventBus
{
    public sealed class RabbitMqIntegrationEventPublisher: IIntegrationEventPublisher
    {
        private readonly IConnection _connection;

        public RabbitMqIntegrationEventPublisher(IConnection connection)
        {
            _connection = connection;
        }

        public Task PublishAsync<TEvent>(TEvent @event, CancellationToken ct)
            where TEvent : class
        {
            using var channel = _connection.CreateModel();

            channel.ExchangeDeclare(
                exchange: "integration.events",
                type: ExchangeType.Topic,
                durable: true,
                autoDelete: false);

            var body = JsonSerializer.SerializeToUtf8Bytes(@event, typeof(TEvent));

            var properties = channel.CreateBasicProperties();
            properties.DeliveryMode = 2; // Persistent
            properties.Type = typeof(TEvent).FullName;

            channel.BasicPublish(
                exchange: "integration.events",
                routingKey: typeof(TEvent).Name,
                basicProperties: properties,
                body: body);

            Console.WriteLine($"[RabbitMQ] Event published: {typeof(TEvent).Name}");

            return Task.CompletedTask;
        }
    }
}
