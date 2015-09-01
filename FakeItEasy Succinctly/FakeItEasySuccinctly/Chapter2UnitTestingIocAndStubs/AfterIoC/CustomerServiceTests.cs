using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter2UnitTestingIocAndStubs.AfterIoC
{
    [TestFixture]
    public class WhenGettingCustomerById
    {
        private const int customerId = 1;
        private Customer result;

        [SetUp]
        public void Given()
        {
            var sut = new CustomerService(new CustomerRepositoryStub());
            result = sut.GetCustomerByCustomerId(customerId);
        }

        [Test]
        public void ReturnsTheCorrectId()
        {
            Assert.That(result.Id, Is.EqualTo(customerId));
        }
    }
}
