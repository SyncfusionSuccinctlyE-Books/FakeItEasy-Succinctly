using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter3IntroducingFakeItEasy.AClassWithAFakeableMethod
{
    [TestFixture]
    public class WhenTryingToFakeAFakeableMethod
    {
        private AClassWithAFakeableMethod sut;

        [SetUp]
        public void Given()
        {
            sut = A.Fake<AClassWithAFakeableMethod>();
            sut.YouCanFakeMe();
        }

        [Test]
        public void YouCanFakeThisMethod()
        {
            A.CallTo(() => sut.YouCanFakeMe()).MustHaveHappened();
        }
    }
}
