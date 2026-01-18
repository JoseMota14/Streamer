using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.IntegrationEvents;
using System.Text.Json;

namespace StreamingService.Infrastructure.EventBus
{
    public sealed class SubscriptionActivatedConsumer
    {
        private readonly IConnection _connection;

        public SubscriptionActivatedConsumer(IConnection connection)
        {
            _connection = connection;
        }

        public void Start()
        {
            var channel = _connection.CreateModel();

            channel.ExchangeDeclare(
                exchange: "integration.events",
                type: ExchangeType.Topic,
                durable: true);

            channel.QueueDeclare(
                queue: "streaming.subscription.activated",
                durable: true,
                exclusive: false,
                autoDelete: false);

            channel.QueueBind(
                queue: "streaming.subscription.activated",
                exchange: "integration.events",
                routingKey: "SubscriptionActivatedIntegrationEvent");

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += async (_, ea) =>
            {
                var json = Encoding.UTF8.GetString(ea.Body.ToArray());

                var integrationEvent =
                    JsonSerializer.Deserialize<SubscriptionActivatedIntegrationEvent>(json);

                Console.WriteLine(
                    $"[StreamingService] Subscription activated for user {integrationEvent!.UserId}");

                channel.BasicAck(ea.DeliveryTag, multiple: false);

                await Task.CompletedTask;
            };

            channel.BasicConsume(
                queue: "streaming.subscription.activated",
                autoAck: false,
                consumer: consumer);
        }
    }
}
