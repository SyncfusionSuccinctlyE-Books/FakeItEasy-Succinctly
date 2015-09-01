using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter7Assertions.MustNotHaveHappened
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class WhenSendingEmailToAllCustomersAndNoCustomersExist
        {
            private ISendEmail emailSender;

            [SetUp]
            public void Given()
            {
                emailSender = A.Fake<ISendEmail>();

                var customerRepository = A.Fake<ICustomerRepository>();
                A.CallTo((() => customerRepository.GetAllCustomers())).Returns(new List<Customer>());

                var sut = new CustomerService(emailSender, customerRepository);
                sut.SendEmailToAllCustomers();
            }

            [Test]
            public void DoesNotSendAnyEmail()
            {
                A.CallTo(() => emailSender.SendMail()).MustNotHaveHappened();
            }
        }
    }
}
