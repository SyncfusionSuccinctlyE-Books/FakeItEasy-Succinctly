using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter2UnitTestingIocAndStubs.FakeItEasy
{
    [TestFixture]
    public class WhenGettingCustomerById
    {
        private const int customerId = 1;
        private Customer result;
        private Customer customer;

        [SetUp]
        public void Given()
        {
            customer = new Customer { Id = customerId };
            
            //create our Fake
            var aFakeCustomerRepository = A.Fake<ICustomerRepository>();

            //set expectations for the call to .GetCustomerBy
            A.CallTo(() => aFakeCustomerRepository.GetCustomerBy(customerId)).Returns(customer);
            
            var sut = new CustomerService(aFakeCustomerRepository);
            result = sut.GetCustomerByCustomerId(customerId);
        }

        [Test]
        public void ReturnsTheCorrectId()
        {
            Assert.That(result.Id, Is.EqualTo(customerId));
        }
    }
}
