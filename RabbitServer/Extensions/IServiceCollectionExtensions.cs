﻿using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace RabbitServer.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(conf =>
            {
                conf.SwaggerDoc("v1.0", new OpenApiInfo { Title = "POC Rabbit API v1.0", Version = "v1.0" });
            });

            return services;
        }

        public static IServiceCollection AddRabbitMassTransit(this IServiceCollection services)
        {
            services
                .AddMassTransit(x =>
                    {
                        x.UsingRabbitMq();
                    })
                .AddMassTransitHostedService();
            return services;
        }
    }
}
