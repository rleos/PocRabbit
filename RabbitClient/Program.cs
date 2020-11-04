using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace RabbitClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .ConfigureLogging(SerilogConfiguration);
                });
        }

        private static void SerilogConfiguration(WebHostBuilderContext webHost, ILoggingBuilder builder)
        {
            builder.ClearProviders();
            builder.AddSerilog(
                new LoggerConfiguration()
                .ReadFrom
                .Configuration(webHost.Configuration)
            .CreateLogger());
        }
    }
}
