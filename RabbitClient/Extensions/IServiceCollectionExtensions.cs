using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitClient.Consumers;

namespace RabbitClient.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMasstransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<MessageConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("event-listener", e =>
                    {
                        e.ConfigureConsumer<MessageConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();
            return services;
        }
    }
}
