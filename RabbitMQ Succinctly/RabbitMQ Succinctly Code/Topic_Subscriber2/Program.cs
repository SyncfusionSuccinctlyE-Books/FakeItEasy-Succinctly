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
                    Console.WriteLine("Publisher listening for Topic <payment.purchaseorder>");
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine();

                    channel.ExchangeDeclare(ExchangeName, "topic");
                    var queueName = channel.QueueDeclare().QueueName;

                    channel.QueueBind(queueName, ExchangeName, "payment.purchaseorder");

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queueName, true, consumer);

                    while (true)
                    {
                        var ea = consumer.Queue.Dequeue();
                        var message = (PurchaseOrder)ea.Body.DeSerialize();
                        var routingKey = ea.RoutingKey;
                        Console.WriteLine("-- Purchase Order - Key <{0}> : {1}, £{2}, {3}, {4}", routingKey, message.CompanyName, message.AmountToPay, message.PaymentDayTerms, message.PoNumber);
                    }
                }
            }
        }
    }
}
