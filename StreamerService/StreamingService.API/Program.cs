using StreamingService.API.Infra;
using StreamingService.Application.EventHandlers;
using StreamingService.Infrastructure.EventBus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();


var scope = app.Services.CreateScope();
var subscriber = scope.ServiceProvider.GetRequiredService<RabbitMqSubscriber>();
var handler = scope.ServiceProvider.GetRequiredService<SubscriptionActivatedHandler>();

subscriber.Subscribe("subscription.events", handler);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
