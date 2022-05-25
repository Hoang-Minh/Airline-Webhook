using System.Text;
using System.Text.Json;
using AirlineWeb.Dtos;
using RabbitMQ.Client;

namespace AirlineWeb.MessageBus
{
    public class MessageBusClient : IMessageBusClient
    {
        public void SendMessage(NotificationMessageDto dto)
        {
            var factory = new ConnectionFactory() {HostName = "localhost", Port = 5672};
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                var message = JsonSerializer.Serialize(dto);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);

                Console.WriteLine("-----> Message Published on Message Bus");
            }
        }
    }
}