using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter5ConfiguringCallsToAFake
{
    public class SendEmailTests
    {
        [TestFixture]
        public class TestingGetEmailServerAddress
        {
            [SetUp]
            public void Given()
            {
                var fake = A.Fake<ISendEmail>();
                A.CallTo(() => fake.GetEmailServerAddress());
            }
        }

        [TestFixture]
        public class TestingSendMail
        {
            [SetUp]
            public void Given()
            {
                var fake = A.Fake<ISendEmail>();
                A.CallTo(() => fake.SendMail());
            }
        }

        [TestFixture]
        public class TestingBodyIsHtml
        {
            [SetUp]
            public void Given()
            {
                var fake = A.Fake<ISendEmail>();
                A.CallTo(() => fake.BodyIsHtml);
            }
        }
    }
}
