using MassTransit;
using Microsoft.Extensions.Logging;
using RabbitContracts.Contracts;
using System.Threading.Tasks;

namespace FaultClient.Consumers
{
    public class MessageFaultConsumer :
        IConsumer<Fault<IMessageContract>>
    {
        private readonly ILogger<MessageFaultConsumer> logger;

        public MessageFaultConsumer(ILogger<MessageFaultConsumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<Fault<IMessageContract>> context)
        {
            this.logger.LogInformation("Receiving error on message : " + context.Message.Message.Message);
        }
    }

}
