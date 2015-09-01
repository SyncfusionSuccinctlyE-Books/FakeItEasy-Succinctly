using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter8Arguments.PassingArgumentsToMethods
{
    [TestFixture]
    public class WhenSendingEmailToAllCustomers
    {
        private ISendEmail emailSender;
        private Customer customer;

        [SetUp]
        public void Given()
        {
            emailSender = A.Fake<ISendEmail>();
            customer = new Customer { Email = "customer@email.com" };

            var customerRepository = A.Fake<ICustomerRepository>();
            A.CallTo(() => customerRepository.GetAllCustomers()).Returns(new List<Customer> { customer });

            var sut = new CustomerService(emailSender, customerRepository);
            sut.SendEmailToAllCustomers();
        }

        [Test]
        public void SendsEmail()
        {
            A.CallTo(() => emailSender.SendMail("acompany@somewhere.com", customer.Email, "subject", "body")).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
