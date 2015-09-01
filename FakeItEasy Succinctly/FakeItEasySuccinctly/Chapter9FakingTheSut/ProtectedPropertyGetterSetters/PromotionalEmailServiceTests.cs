using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter9FakingTheSut.ProtectedPropertyGetterSetters
{
    public class WhenSendingPromotionalEmail
    {
        private List<Customer> customers;
        private ISendEmail emailSender;
        private const string subject = "Subject";
        private const string body = "Body";
        private const string fromAddress = "fromAddress";

        [SetUp]
        public void Given()
        {
            customers = new List<Customer>
            {
                new Customer { Email = "customer1@email.com" },
                new Customer { Email = "customer2@email.com" }
            };

            emailSender = A.Fake<ISendEmail>();
            var customerRepository = A.Fake<ICustomerRepository>();
            A.CallTo(() => customerRepository.GetAllCustomersWithOrderTotalsOfOneHundredOrGreater()).Returns(customers);

            var sut = A.Fake<PromotionalEmailService>(x => x.WithArgumentsForConstructor(() => new PromotionalEmailService(customerRepository, emailSender)));
            A.CallTo(sut).Where(x => x.Method.Name == "get_FromEmailAddress").WithReturnType<string>().Returns(fromAddress);
            sut.SendEmail(subject, body);
        }

        [Test]
        public void SendsTheCorrectAmountOfTimes()
        {
            A.CallTo(() => emailSender.SendMail(fromAddress, A<string>._, subject, body)).MustHaveHappened(Repeated.Exactly.Times(customers.Count()));
        }

        [Test]
        public void SendsToCorrectCustomers()
        {
            foreach (var customer in customers)
            {
                A.CallTo(() => emailSender.SendMail(fromAddress, customer.Email, subject, body)).MustHaveHappened(Repeated.Exactly.Once);   
            }
        }
    }
}

