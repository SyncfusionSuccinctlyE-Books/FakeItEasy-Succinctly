using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter3IntroducingFakeItEasy.AClassWithAnUnfakeableMethod
{
    [TestFixture]
    public class WhenTryingToFakeAndUnfakeableMethod
    {
        private AClassWithAnUnfakeableMethod sut;

        [SetUp]
        public void Given()
        {
            sut = A.Fake<AClassWithAnUnfakeableMethod>();
            sut.YouCantFakeMe();
        }

        [Test]
        public void YouWillGetAnException()
        {
            A.CallTo(() => sut.YouCantFakeMe()).MustHaveHappened();
        }
    }
}
