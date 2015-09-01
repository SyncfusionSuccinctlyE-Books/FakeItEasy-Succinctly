using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter8Arguments.PassingArgumentsToMethods.ATIgnored
{
    [TestFixture]
    public class WhenSendingEmailToCustomersAndNoCustomersExist
    {
        private ISendEmail emailSender;

        [SetUp]
        public void Given()
        {
            emailSender = A.Fake<ISendEmail>();
            var sut = new CustomerService(emailSender, A.Fake<ICustomerRepository>());
            sut.SendEmailToAllCustomers();
        }

        [Test]
        public void DoesNotSendEmail()
        {
            A.CallTo(() => emailSender.SendMail(A<string>.Ignored, A<string>.Ignored, A<string>.Ignored, A<string>.Ignored)).MustNotHaveHappened();
        }
    }
}
