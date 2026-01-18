using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using SubscriptionService.Application.Abstractions;
using SubscriptionService.Application.Commands;
using SubscriptionService.Application.DTOs;
using SubscriptionService.Application.Interfaces;
using SubscriptionService.Application.Queries;
using SubscriptionService.Domain;
using SubscriptionService.Domain.Observer;
using SubscriptionService.Infrastructure.EventBus;
using SubscriptionService.Infrastructure.Factories;
using SubscriptionService.Infrastructure.Persistence;
using SubscriptionService.Infrastructure.UnitOfWork;

namespace SubscriptionService.API.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddBaseServices(services);
            AddInfra(services);
            AddCQRS(services);
            AddBusConfig(services);
            AddEventDispose(services);

            return services;
        }

        private static void AddEventDispose(IServiceCollection services)
        {
            services.AddSingleton<IConnection>(_ =>
            {
                //var factory = new ConnectionFactory
                //{
                //    Uri = new Uri("amqp://guest:guest@localhost:5672")
                //};

                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    UserName = "guest",
                    Password = "guest"
                };

                return factory.CreateConnection();
            });

            // Integration Event Publisher
            services.AddScoped(typeof(IDomainEventHandler<>),
                               typeof(ConsoleLoggingEventHandler<>));

            services.AddSingleton<IIntegrationEventPublisher,RabbitMqIntegrationEventPublisher>();

            services.AddSingleton<DomainEventDispatcher>();
        }

        private static void AddCQRS(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<SubscribeCommand>, SubscribeCommandHandler>();
            services.AddScoped<ICommandHandler<SuspendSubscriptionCommand>, SuspendSubscriptionCommandHandler>();
            services.AddScoped<IQueryHandler<GetSubscriptionQuery, SubscriptionDto>, GetSubscriptionQueryHandler>();
        }

        private static void AddBusConfig(IServiceCollection services)
        {
            //services.AddSingleton<IIntegrationEventPublisher, RabbitMqIntegrationEventPublisher>();

            //if (builder.Environment.IsDevelopment())
            //{
            //    builder.Services.AddSingleton<IIntegrationEventPublisher,
            //        InMemoryIntegrationEventPublisher>();
            //}
            //else
            //{
            //    builder.Services.AddSingleton<IIntegrationEventPublisher,
            //        RabbitMqIntegrationEventPublisher>();
            //}
        }

        private static void AddInfra(IServiceCollection services)
        {
            services.AddDbContext<SubscriptionDbContext>(options =>
            {
                options.UseInMemoryDatabase("SubscriptionDb");
            });

            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IPlanFactory, PlanFactory>();
        }

        private static void AddBaseServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
