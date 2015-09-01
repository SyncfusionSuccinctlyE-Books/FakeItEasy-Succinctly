using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter7Assertions.MustHaveHappened.BasicUsage
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class WhenSendingEmailToAllCustomers
        {
            private ISendEmail emailSender;

            [SetUp]
            public void Given()
            {
                emailSender = A.Fake<ISendEmail>();

                var customerRepository = A.Fake<ICustomerRepository>();
                A.CallTo(() => customerRepository.GetAllCustomers()).Returns(new List<Customer> { new Customer() });

                var sut = new CustomerService(emailSender, customerRepository);
                sut.SendEmailToAllCustomers();
            }

            [Test]
            public void SendsEmail()
            {
                A.CallTo(() => emailSender.SendMail()).MustHaveHappened();
            }
        }
    }
}
