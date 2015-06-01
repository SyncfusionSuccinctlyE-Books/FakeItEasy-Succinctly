using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Examples;

namespace RabbitMQ.Examples
{
    class Program
    {
        private static IConnection _connection;
        private static IModel _channel;
        private static string _replyQueueName;
        private static QueueingBasicConsumer _consumer;

        static void Main()
        {
            SetupClient();

            MakePayment(new Payment { AmountToPay = 25.0m, CardNumber = "1234123412341234", Name = "Mr F Bloggs"});
            MakePayment(new Payment { AmountToPay = 5.0m, CardNumber = "1234123412341234", Name = "Mr D Wibble" });
            MakePayment(new Payment { AmountToPay = 225.0m, CardNumber = "1234123412341234", Name = "Mr B Smith" });
            MakePayment(new Payment { AmountToPay = 255.0m, CardNumber = "1234123412341234", Name = "Mr S Jones" });
            MakePayment(new Payment { AmountToPay = 255.0m, CardNumber = "1234123412341234", Name = "Mr A Dibbles" });
            MakePayment(new Payment { AmountToPay = 125.0m, CardNumber = "1234123412341234", Name = "Mr H Howser" });
            MakePayment(new Payment { AmountToPay = 27.0m, CardNumber = "1234123412341234", Name = "Mr J Jupiter" });
            MakePayment(new Payment { AmountToPay = 925.0m, CardNumber = "1234123412341234", Name = "Mr Z Zimzibar" });
            MakePayment(new Payment { AmountToPay = 325.0m, CardNumber = "1234123412341234", Name = "Mr G Goggie" });
            MakePayment(new Payment { AmountToPay = 925.0m, CardNumber = "1234123412341234", Name = "Mr U Bloggs" });
        }

        private static void SetupClient()
        {
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _replyQueueName = _channel.QueueDeclare();
            _consumer = new QueueingBasicConsumer(_channel);
            _channel.BasicConsume(_replyQueueName, true, _consumer);
        }

        public static string MakePayment(Payment payment)
        {
            var corrId = Guid.NewGuid().ToString();
            var props = _channel.CreateBasicProperties();
            props.ReplyTo = _replyQueueName;
            props.CorrelationId = corrId;
            
            _channel.BasicPublish("", "rpc_queue", props, payment.Serialize());

            while (true)
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Payment Made for Card : {0}, for £{1}", payment.CardNumber, payment.AmountToPay);
                Console.WriteLine("Correlation ID = {0}", corrId);

                var ea = _consumer.Queue.Dequeue();
                if (ea.BasicProperties.CorrelationId != corrId) continue;

                var authCode = Encoding.UTF8.GetString(ea.Body);
                Console.WriteLine("Reply Auth Code : {0}", authCode);
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("");

                return authCode;
            }
        }
    }
}
