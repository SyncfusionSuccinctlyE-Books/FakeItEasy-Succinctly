using System;
using RabbitMQ.Client;

namespace RabbitMQ.Examples
{
    class Program
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _model;

        private const string ExchangeName = "DirectRouting_Exchange";

        static void Main()
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

            var purchaseOrder1 = new PurchaseOrder{AmountToPay = 50.0m, CompanyName = "Company A", PaymentDayTerms = 75, PoNumber = "123434A"};
            var purchaseOrder2 = new PurchaseOrder { AmountToPay = 150.0m, CompanyName = "Company B", PaymentDayTerms = 75, PoNumber = "193434B" };
            var purchaseOrder3 = new PurchaseOrder { AmountToPay = 12.0m, CompanyName = "Company C", PaymentDayTerms = 75, PoNumber = "196544A" };
            var purchaseOrder4 = new PurchaseOrder { AmountToPay = 2150.0m, CompanyName = "Company D", PaymentDayTerms = 75, PoNumber = "234434H" };
            var purchaseOrder5 = new PurchaseOrder { AmountToPay = 2150.0m, CompanyName = "Company E", PaymentDayTerms = 75, PoNumber = "876434W" };
            var purchaseOrder6 = new PurchaseOrder { AmountToPay = 7150.0m, CompanyName = "Company F", PaymentDayTerms = 75, PoNumber = "1423474U" };
            var purchaseOrder7 = new PurchaseOrder { AmountToPay = 3150.0m, CompanyName = "Company G", PaymentDayTerms = 75, PoNumber = "1932344O" };
            var purchaseOrder8 = new PurchaseOrder { AmountToPay = 3190.0m, CompanyName = "Company H", PaymentDayTerms = 75, PoNumber = "1123457Q" };
            var purchaseOrder9 = new PurchaseOrder { AmountToPay = 50.0m, CompanyName = "Company I", PaymentDayTerms = 75, PoNumber =   "1595344R" };
            var purchaseOrder10 = new PurchaseOrder { AmountToPay = 2150.0m, CompanyName = "Company J", PaymentDayTerms = 75, PoNumber = "656734L" };

            CreateConnection();

            SendPayment(payment1);
            SendPayment(payment2);
            SendPayment(payment3);
            SendPayment(payment4);
            SendPayment(payment5);
            SendPayment(payment6);
            SendPayment(payment7);
            SendPayment(payment8);
            SendPayment(payment9);
            SendPayment(payment10);

            SendPurchaseOrder(purchaseOrder1);
            SendPurchaseOrder(purchaseOrder2);
            SendPurchaseOrder(purchaseOrder3);
            SendPurchaseOrder(purchaseOrder4);
            SendPurchaseOrder(purchaseOrder5);
            SendPurchaseOrder(purchaseOrder6);
            SendPurchaseOrder(purchaseOrder7);
            SendPurchaseOrder(purchaseOrder8);
            SendPurchaseOrder(purchaseOrder9);
            SendPurchaseOrder(purchaseOrder10);
        }

        private static void SendPayment(Payment payment)
        {
            SendMessage(payment.Serialize(), "CardPayment");
            Console.WriteLine(" Payment Sent {0}, £{1}", payment.CardNumber, payment.AmountToPay); 
        }

        private static void SendPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            SendMessage(purchaseOrder.Serialize(), "PurchaseOrder");
            Console.WriteLine(" Purchase Order Sent {0}, £{1}, {2}, {3}", purchaseOrder.CompanyName, purchaseOrder.AmountToPay, purchaseOrder.PaymentDayTerms, purchaseOrder.PoNumber); 
        }

        private static void CreateConnection()
        {
            _factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(ExchangeName, "direct");
        }

        private static void SendMessage(byte[] message, string routingKey)
        {                       
            _model.BasicPublish(ExchangeName, routingKey, null, message);          
        }
    }
}
