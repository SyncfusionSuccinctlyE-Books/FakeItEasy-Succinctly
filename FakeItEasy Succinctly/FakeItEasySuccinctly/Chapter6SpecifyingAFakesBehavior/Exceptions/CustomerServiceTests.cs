using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.Exceptions
{
    public class WhenSendingEmailToAllCustomersAndThereIsAnException
    {
        [SetUp]
        public void Given()
        {
            var customerRepository = A.Fake<ICustomerRepository>();
            var customers = new List<Customer>() { new Customer { EmailAddress = "someone@somewhere.com" } };
            A.CallTo(() => customerRepository.GetAllCustomers()).Returns(customers);

            var emailSender = A.Fake<ISendEmail>();
            A.CallTo(() => emailSender.SendMail(customers)).Throws(new BadCustomerEmailException());

            var sut = new CustomerService(emailSender, customerRepository);
            sut.SendEmailToAllCustomers();
        }
    }
}