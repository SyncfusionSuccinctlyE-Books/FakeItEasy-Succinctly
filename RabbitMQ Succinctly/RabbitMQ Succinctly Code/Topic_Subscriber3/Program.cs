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
                    Console.WriteLine("Publisher listening on all payment topics");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine();

                    channel.ExchangeDeclare(ExchangeName, "topic");
                    var queueName = channel.QueueDeclare().QueueName;

                    channel.QueueBind(queueName, ExchangeName, "payment.*");

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queueName, true, consumer);

                    while (true)
                    {
                        var ea = consumer.Queue.Dequeue();                       
                        var reference = ea.Body.DeSerialize();

                        var order = reference as PurchaseOrder;
                        if (order != null)
                        {
                            Console.WriteLine("Purchase Order Recieved from company '{0}'", order.CompanyName);
                        }

                        var payment = reference as Payment;
                        if (payment != null)
                        {
                            Console.WriteLine("Card Payment Recieved from person '{0}'", payment.Name);
                        }
                    }
                }
            }
        }
    }
}
