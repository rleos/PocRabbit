using FaultClient.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace FaultClient.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMasstransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<MessageFaultConsumer>()
                    .Endpoint(e =>
                    {
                        e.Name = "error_message";
                    });
                x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
            });

            services.AddMassTransitHostedService();
            return services;
        }
    }
}
