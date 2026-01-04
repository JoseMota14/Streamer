using RabbitMQ.Client;
using SubscriptionService.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SubscriptionService.Infrastructure.EventBus
{
    public sealed class RabbitMqIntegrationEventPublisher : IIntegrationEventPublisher
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
                durable: true);

            var body = JsonSerializer.SerializeToUtf8Bytes(@event);

            channel.BasicPublish(
                exchange: "integration.events",
                routingKey: typeof(TEvent).Name,
                basicProperties: null,
                body: body);

            return Task.CompletedTask;
        }
    }
}
