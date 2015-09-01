using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter9FakingTheSut
{
    [TestFixture]
    public class WhenSendingPromotionalEmail
    {
        private ISendEmail emailSender;
        private List<Customer> customers;
        private const string emailSubject = "EmailSubject";
        private const string emailBody = "EmailBody";
        private const string theConfiguredFromAddress = "someone@somecompany.com";

        [SetUp]
        public void Given()
        {
            customers = new List<Customer>
            {
                new Customer { Email = "customer1@email.com" },
                new Customer { Email = "customer2@email.com" }
            };

            var customerRepository = A.Fake <ICustomerRepository>();
            A.CallTo(() => customerRepository.GetAllCustomersWithOrderTotalsOfOneHundredOrGreater()).Returns(customers);

            emailSender = A.Fake<ISendEmail>();

            var sut = A.Fake<AdminEmailService>(x => x.WithArgumentsForConstructor(() => new AdminEmailService(customerRepository, emailSender)));
            A.CallTo(sut).Where(x => x.Method.Name == "GetFromEmailAddress").WithReturnType<string>().Returns(theConfiguredFromAddress);

            sut.SendPromotionalEmail(emailSubject, emailBody);
        }

        [Test]
        public void SendsTheCorrectAmountOfTimes()
        {
            A.CallTo(() => emailSender.SendMail(theConfiguredFromAddress, A<string>._, emailSubject, emailBody)).MustHaveHappened(Repeated.Exactly.Twice);
        }

        [Test]
        public void SendsTheCorrectAmountOfTimesBetter()
        {
            A.CallTo(() => emailSender.SendMail(theConfiguredFromAddress, A<string>._, emailSubject, emailBody)).MustHaveHappened(Repeated.Exactly.Times(customers.Count()));
        }

        [Test]
        public void SendsToCorrectCustomers()
        {
            A.CallTo(() => emailSender.SendMail(theConfiguredFromAddress, customers[0].Email, emailSubject, emailBody)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => emailSender.SendMail(theConfiguredFromAddress, customers[1].Email, emailSubject, emailBody)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void SendsToCorrectCustomersBetter()
        {
            foreach (var customer in customers)
                A.CallTo(() => emailSender.SendMail(theConfiguredFromAddress, customer.Email, emailSubject, emailBody)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
