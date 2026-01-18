using Microsoft.EntityFrameworkCore;
using StreamingService.Domain.Repositories;
using StreamingService.Infrastructure.Persistence;
using RabbitMQ.Client;
using StreamingService.Application.EventHandlers;
using StreamingService.Infrastructure.EventBus;

namespace StreamingService.API.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StreamingDbContext>(options =>
            {
                options.UseInMemoryDatabase("StreamingDb");
            });

            services.AddScoped<IStreamingPermissionRepository, StreamingPermissionRepository>();

            RegisterEvents(services);

            return services;
        }

        public static void RegisterEvents(IServiceCollection services)
        {
            services.AddSingleton<IConnection>(_ =>
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    UserName = "guest",
                    Password = "guest",
                    DispatchConsumersAsync = true
                };

                return factory.CreateConnection();
            });

            services.AddSingleton<SubscriptionActivatedConsumer>();
        }

        public static void AddEvents(IServiceCollection services)
        {
            services.AddSingleton<IConnection>(_ =>
            {
                var factory = new ConnectionFactory
                {
                    Uri = new Uri("amqp://guest:guest@localhost:5672")
                };
                return factory.CreateConnection();
            });

            // Handler
            services.AddScoped<SubscriptionActivatedHandler>();

            // Subscriber
            services.AddSingleton<RabbitMqSubscriber>();
        }
    }
}
