using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter8Arguments.ConstrainingArguments.ThatMatches
{
    [TestFixture]
    public class WhenSendingEmailToAllCustomers
    {
        private ISendEmail emailSender;
        private const string customersEmail = "somecustomer@somewhere.com";

        [SetUp]
        public void Given()
        {
            emailSender = A.Fake<ISendEmail>();
            var customerRepository = A.Fake<ICustomerRepository>();
            A.CallTo(() => customerRepository.GetAllCustomers()).Returns(new List<Customer> { new Customer { Email = customersEmail }});
            var sut = new CustomerService(emailSender, customerRepository);
            sut.SendEmailToAllCustomers();
        }

        [Test]
        public void SendsEmail()
        {
            A.CallTo(() => emailSender.SendMail(A<Email>.That.Matches(email => email.To == customersEmail))).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
