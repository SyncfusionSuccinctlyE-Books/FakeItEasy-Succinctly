using System;
using RabbitMQ.Client;

namespace RabbitMQ.Examples
{
    class Program
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _model;
        
        private const string QueueName = "StandardQueue_ExampleQueue";

        public static void Main()
        {            
            var payment1 = new Payment { AmountToPay = 25.0m, CardNumber = "1234123412341234" };
            var payment2 = new Payment { AmountToPay = 5.0m, CardNumber = "1234123412341234" };
            var payment3 = new Payment { AmountToPay = 2.0m, CardNumber = "1234123412341234" };
            var payment4 = new Payment { AmountToPay = 17.0m, CardNumber = "1234123412341234" };
            var payment5 = new Payment { AmountToPay = 300.0m, CardNumber = "1234123412341234" };
            var payment6 = new Payment { AmountToPay = 350.0m, CardNumber = "1234123412341234" };
            var payment7 = new Payment { AmountToPay = 295.0m, CardNumber = "1234123412341234" };
            var payment8 = new Payment { AmountToPay = 5625.0m, CardNumber = "1234123412341234" };
            var payment9 = new Payment { AmountToPay = 5.0m, CardNumber = "1234123412341234" };
            var payment10 = new Payment { AmountToPay = 12.0m, CardNumber = "1234123412341234" };
            
            CreateQueue();            
            
            SendMessage(payment1);
            SendMessage(payment2);
            SendMessage(payment3);
            SendMessage(payment4);
            SendMessage(payment5);
            SendMessage(payment6);
            SendMessage(payment7);
            SendMessage(payment8);
            SendMessage(payment9);
            SendMessage(payment10);
                        
            Recieve();

            Console.ReadLine();
        }

        private static void CreateQueue()
        {
            _factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest"};
            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();                
            _model.QueueDeclare(QueueName, true, false, false, null);            
        }

        private static void SendMessage(Payment message)
        {
            _model.BasicPublish("", QueueName, null, message.Serialize());
            Console.WriteLine(" [x] Payment Message Sent : {0} : {1}", message.CardNumber, message.AmountToPay);            
        }

        public static void Recieve()
        {
            var consumer = new QueueingBasicConsumer(_model);

            var msgCount = GetMessageCount(_model, QueueName);
            _model.BasicConsume(QueueName, true, consumer);
                    
            var count = 0;

            while (count < msgCount)
            {                        
                var message = (Payment)consumer.Queue.Dequeue().Body.DeSerialize();

                Console.WriteLine("----- Received {0} : {1}", message.CardNumber, message.AmountToPay);
                count++;
            }                   
        }

        private static uint GetMessageCount(IModel channel, string queueName)
        {
            var results = channel.QueueDeclare(queueName, true, false, false, null);
            return results.MessageCount;                
        }
    }
}
