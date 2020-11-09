using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using SecondClient.Consumers;

namespace SecondClient.Extensions
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
                        e.Name = "second_client";
                    });
                x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
            });

            services.AddMassTransitHostedService();
            return services;
        }
    }
}
