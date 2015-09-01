using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter8Arguments.ConstrainingArguments.DealingWithObject
{
    [TestFixture]
    public class WhenSendingEmailToPreferredCustomers
    {
        private List<Customer> customers;
        private ISendEmail emailSender;
        private ICustomerRepository customerRepository;

        [SetUp]
        public void Given()
        {
            emailSender = A.Fake<ISendEmail>();
            customers = new List<Customer> { new Customer { Email ="customer1@email.com", IsPreferred = true } };
            customerRepository = A.Fake<ICustomerRepository>();
            A.CallTo(() => customerRepository.GetAllCustomers()).Returns(customers);
            var sut = new CustomerService(emailSender, customerRepository);
            sut.SendEmailToPreferredCustomers();
        }

        [Test]
        public void SendsEmail()
        {
            A.CallTo(() => emailSender.SendMail(A<Email>.That.Matches(x => (x.EmailType as PreferredCustomerEmail).Email == customers[0].Email)))
                .MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}