using System;
using RabbitMQ.Client;

namespace RabbitMQ.Examples
{
    class Program
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;

        private const string ExchangeName = "Topic_Exchange";

        static void Main()
        {
            _factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            using (_connection = _factory.CreateConnection())
            {
                using (var channel = _connection.CreateModel())
                {
                    Console.WriteLine("Publisher listening for Topic <payment.card>");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine();

                    channel.ExchangeDeclare(ExchangeName, "topic");
                    var queueName = channel.QueueDeclare().QueueName;

                    channel.QueueBind(queueName, ExchangeName, "payment.card");

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queueName, true, consumer);

                    while (true)
                    {
                        var ea = consumer.Queue.Dequeue();
                        var message = (Payment)ea.Body.DeSerialize();
                        var routingKey = ea.RoutingKey;
                        Console.WriteLine("--- Payment - Key <{0}> : {1} : {2}", routingKey, message.CardNumber, message.AmountToPay);
                    }
                }
            }
        }
    }
}
