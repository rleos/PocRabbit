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
                x.AddConsumer<MessageConsumer>()
                    .Endpoint(e =>
                    {
                        e.Name = "first_client";
                    });
                x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
            });

            services.AddMassTransitHostedService();
            return services;
        }
    }
}
