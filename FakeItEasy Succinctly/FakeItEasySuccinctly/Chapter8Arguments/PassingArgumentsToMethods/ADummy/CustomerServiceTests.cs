using System.Linq;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter8Arguments.PassingArgumentsToMethods.ADummy
{
    [TestFixture]
    public class WhenSendingAnEmailWithAnEmptyToAddress
    {
        private Result result;

        [SetUp]
        public void Given()
        {
            var sut = new CustomerService(A.Fake<ISendEmail>());
            result = sut.SendEmail(A.Dummy<string>(), "");
        }

        [Test]
        public void ReturnsErrorMessage()
        {
            Assert.That(result.ErrorMessages.Single(), Is.EqualTo("Cannot send an email with an empty to address"));
        }
    }
}

