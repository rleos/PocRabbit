using Microsoft.AspNetCore.Builder;

namespace RabbitServer.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(conf =>
            {
                conf.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Poc Rabbit API v1.0");
                conf.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            return app;
        }

    }
}
