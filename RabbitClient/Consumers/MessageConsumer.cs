﻿using MassTransit;
using Microsoft.Extensions.Logging;
using RabbitContracts.Contracts;
using System.Threading.Tasks;

namespace RabbitClient.Consumers
{
    public class MessageConsumer : IConsumer<IMessageContract>
    {
        private readonly ILogger<MessageConsumer> logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<IMessageContract> context)
        {
            this.logger.LogInformation( "First client receiving following message : " + context.Message.Message);
            return Task.CompletedTask;
        }
    }
}