using AgendaApp.Service.Interfaces;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Service.Impementations
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly ILogger _logger;

        public RabbitMqService(
            ILogger<RabbitMqService> logger)
        {            
            _logger = logger;
            _logger.LogInformation($"The RabbitMqService was invoked");
        }

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory { HostName = "host.docker.internal" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "alert-creating",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "alert-creating",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
