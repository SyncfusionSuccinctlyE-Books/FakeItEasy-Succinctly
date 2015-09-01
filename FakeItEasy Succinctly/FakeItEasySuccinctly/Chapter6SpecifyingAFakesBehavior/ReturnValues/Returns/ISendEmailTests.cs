using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.ReturnValues.Returns
{
    [TestFixture]
    public class SendEmailTests
    {
        private const string smtpServerAddress = "SmtpServerAddress";

        [SetUp]
        public void Given()
        {
            var emailSender = A.Fake<ISendEmail>();
            A.CallTo(() => emailSender.GetEmailServerAddress()).Returns("SMTPServerAddress");
            A.CallTo(() => emailSender.GetEmailServerAddress()).Returns(smtpServerAddress);
            A.CallTo(() => emailSender.GetAllCcRecipients()).Returns(new List<string> { "CcRecipient1@somewhere.com", "CcRecipient2@somewhere.com" });
        }
    }
}