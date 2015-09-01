using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.DoingNothing
{
    public class CustomerServiceTests
    {
        [TestFixture]
        public class ATestWhereWeDontCareAboutISendEmailBySpecifyingDoesNothing
        {
            [SetUp]
            public void Given()
            {
                var customerRepository = A.Fake<ICustomerRepository>();
                A.CallTo(() => customerRepository.GetAllCustomers()).Returns(new List<Customer> { new Customer() });
                var emailSender = A.Fake<ISendEmail>();
                A.CallTo(() => emailSender.SendMail()).DoesNothing();
                var sut = new CustomerService(emailSender, customerRepository);
            }
        }

        [TestFixture]
        public class ATestWhereWeDontCareAboutISendEmail
        {
            [SetUp]
            public void Given()
            {
                var customerRepository = A.Fake<ICustomerRepository>();
                A.CallTo(() => customerRepository.GetAllCustomers()).Returns(new List<Customer> { new Customer() });
                var sut = new CustomerService(A.Fake<ISendEmail>(), customerRepository);
            }
        }
    }
}
