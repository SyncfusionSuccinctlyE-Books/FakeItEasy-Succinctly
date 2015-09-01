using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter7Assertions.MustHaveHappened.Repeated
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class WhenSendingEmailToOneCustomer
        {
            private ISendEmail emailSender;

            [SetUp]
            public void Given()
            {
                emailSender = A.Fake<ISendEmail>();

                var customerRepository = A.Fake<ICustomerRepository>();
                A.CallTo(() => customerRepository.GetAllCustomers()).Returns(new List<Customer> { new Customer(), new Customer() });

                var sut = new CustomerService(emailSender, customerRepository);
                sut.SendEmailToAllCustomers();
            }

            [Test]
            public void SendsEmail()
            {
                A.CallTo(() => emailSender.SendMail()).MustHaveHappened(FakeItEasy.Repeated.Exactly.Twice);
            }
        }

        [TestFixture]
        public class WhenSendingEmailToTwoCustomers
        {
            private ISendEmail emailSender;

            [SetUp]
            public void Given()
            {
                emailSender = A.Fake<ISendEmail>();

                var customerRepository = A.Fake<ICustomerRepository>();
                A.CallTo(() => customerRepository.GetAllCustomers())
                    .Returns(new List<Customer> { new Customer(), new Customer() });

                var sut = new CustomerService(emailSender, customerRepository);
                sut.SendEmailToAllCustomers();
            }

            [Test]
            public void SendsEmail()
            {
                A.CallTo(() => emailSender.SendMail()).MustHaveHappened(FakeItEasy.Repeated.Exactly.Twice);
            }
        }

        [TestFixture]
        public class WhenSendingEmailToAllCustomers
        {
            private ISendEmail emailSender;
            private List<Customer> customers;

            [SetUp]
            public void Given()
            {
                emailSender = A.Fake<ISendEmail>();
                customers = new List<Customer> { new Customer(), new Customer() };

                var customerRepository = A.Fake<ICustomerRepository>();
                A.CallTo(() => customerRepository.GetAllCustomers()).Returns(customers);

                var sut = new CustomerService(emailSender, customerRepository);
                sut.SendEmailToAllCustomers();
            }

            [Test]
            public void SendsTwoEmails()
            {
                A.CallTo(() => emailSender.SendMail()).MustHaveHappened(FakeItEasy.Repeated.Exactly.Times(customers.Count));
            }
        }
    }
}
