using RabbitMQ.Client;

namespace SubscriptionService.Infrastructure.EventBus
{
    public sealed class RabbitMqConnection
    {
        public IConnection Create(string connectionString)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(connectionString)
            };

            return factory.CreateConnection();
        }
    }
}
