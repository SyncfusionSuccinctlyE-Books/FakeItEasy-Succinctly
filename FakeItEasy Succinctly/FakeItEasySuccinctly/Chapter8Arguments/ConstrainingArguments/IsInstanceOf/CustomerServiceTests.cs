using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter8Arguments.ConstrainingArguments.IsInstanceOf
{
    [TestFixture]
    public class WhenCreatingACustomer
    {
        private IBus bus;

        [SetUp]
        public void Given()
        {
            bus = A.Fake<IBus>();
            var sut = new CustomerService(bus);
            sut.CreateCustomer("FirstName", "LastName", "Email");
        }

        [Test]
        public void SendsCreateCustomer()
        {
            A.CallTo(() => bus.Send(A<object>.That.IsInstanceOf(typeof(CreateCustomer)))).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
