using System;
using System.Globalization;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Examples
{
    class Program
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _channel;        
        private static QueueingBasicConsumer _consumer;
        private static Random _rnd;

        private static void Main()
        {
            CreateConnection();
            
            Console.WriteLine("Awaiting Remote Procedure Call Requests");            

            while (true)
            {
                GetMessageFromQueue();
            }               
        }

        private static void GetMessageFromQueue()
        {
            string response = null;
            var ea = _consumer.Queue.Dequeue();
            var props = ea.BasicProperties;
            var replyProps = _channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;

            Console.WriteLine("----------------------------------------------------------");            

            try
            {
                response = MakePayment(ea);
                Console.WriteLine("Correlation ID = {0}", props.CorrelationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ERROR : " + ex.Message);
                response = "";
            }
            finally
            {
                if (response != null)
                {
                    var responseBytes = Encoding.UTF8.GetBytes(response);
                    _channel.BasicPublish("", props.ReplyTo, replyProps, responseBytes);
                }
                _channel.BasicAck(ea.DeliveryTag, false);
            }

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("");
        }

        private static string MakePayment(BasicDeliverEventArgs ea)
        {
            var payment = (Payment) ea.Body.DeSerialize();
            var response = _rnd.Next(1000, 100000000).ToString(CultureInfo.InvariantCulture);
            Console.WriteLine("Payment -  {0} : £{1} : Auth Code <{2}> ", payment.CardNumber, payment.AmountToPay, response);

            return response;
        }

        private static void CreateConnection()
        {
            _factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            _connection = _factory.CreateConnection();            
            _channel = _connection.CreateModel();               
            _channel.QueueDeclare("rpc_queue", false, false, false, null);
            _channel.BasicQos(0, 1, false);
            _consumer = new QueueingBasicConsumer(_channel);
            _channel.BasicConsume("rpc_queue", false, _consumer);
            _rnd = new Random();
        }

    }
}
