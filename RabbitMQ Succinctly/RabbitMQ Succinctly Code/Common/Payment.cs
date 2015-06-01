using System;

namespace RabbitMQ.Examples
{
    [Serializable]
    public class Payment
    {
        public decimal AmountToPay;
        public string CardNumber;        
        public string Name;
    }
}
