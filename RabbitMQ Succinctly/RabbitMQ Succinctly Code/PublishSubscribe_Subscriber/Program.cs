using System;
using RabbitMQ.Client;

namespace RabbitMQ.Examples
{
    class Program
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static QueueingBasicConsumer _consumer;

        private const string ExchangeName = "PublishSubscribe_Exchange";

        static void Main()
        {
            _factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            using (_connection = _factory.CreateConnection())
            {
                using (var channel = _connection.CreateModel())
                {                    
                    var queueName = DeclareAndBindQueueToExchange(channel);
                    channel.BasicConsume(queueName, true, _consumer);
                  
                    while (true)
                    {                        
                        var ea = _consumer.Queue.Dequeue();
                        var message = (Payment)ea.Body.DeSerialize();

                        Console.WriteLine("----- Payment Processed {0} : {1}", message.CardNumber, message.AmountToPay);
                    }
                }
            }
        }

        private static string DeclareAndBindQueueToExchange(IModel channel)
        {
            channel.ExchangeDeclare(ExchangeName, "fanout");
            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queueName, ExchangeName, "");
            _consumer = new QueueingBasicConsumer(channel);
            return queueName;
        }
    }
}
