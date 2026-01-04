using StreamingService.Application.EventHandlers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;

namespace StreamingService.Infrastructure.EventBus
{
    public sealed class RabbitMqSubscriber
    {
        private readonly IConnection _connection;

        public RabbitMqSubscriber(IConnection connection)
        {
            _connection = connection;
        }

        public void Subscribe<TEvent>(string queueName, IIntegrationEventHandler<TEvent> handler)
        {
            using var channel = _connection.CreateModel();

            channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += async (sender, args) =>
            {
                var body = args.Body.ToArray();
                var @event = JsonSerializer.Deserialize<TEvent>(body);

                if (@event != null)
                    await handler.HandleAsync(@event, CancellationToken.None);

                channel.BasicAck(args.DeliveryTag, multiple: false);
            };

            channel.BasicConsume(queueName, autoAck: false, consumer: consumer);

            Console.WriteLine($"[RabbitMqSubscriber] Subscribed to {queueName}");
        }
    }
}
