using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitContracts.Contracts;
using System.Threading.Tasks;

namespace RabbitServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RabbitController : ControllerBase
    {
        private readonly ILogger<RabbitController> logger;
        private readonly IPublishEndpoint publishEndpoint;

        public RabbitController(ILogger<RabbitController> logger, IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> SendMessageAsync(string messageToSend)
        {
            this.logger.LogInformation("Sending following message : " + messageToSend);
            await this.publishEndpoint
                .Publish<IMessageContract>(new
                {
                    Message = messageToSend
                });
            return this.Ok();
        }
    }
}
