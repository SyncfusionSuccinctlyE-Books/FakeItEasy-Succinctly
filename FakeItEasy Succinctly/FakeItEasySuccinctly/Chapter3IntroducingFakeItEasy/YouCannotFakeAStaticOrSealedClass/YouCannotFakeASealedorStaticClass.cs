using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter3IntroducingFakeItEasy.YouCannotFakeAStaticOrSealedClass
{
    //[TestFixture]
    //public class WhenTryingToFakeAStaticClass
    //{
    //    [SetUp]
    //    public void Given()
    //    {
    //        var sut = A.Fake<YouCannotFakeAStaticClass>();
    //    }
    //}

    public static class YouCannotFakeAStaticClass
    {
    }

    public sealed class YouCannotFakeASealedClass
    {
        public void DoSomething()
        {
            //some implementation
        }
    }

    [TestFixture]
    public class WhenTryingToFakeASealedClass
    {
        private YouCannotFakeASealedClass sut;

        [SetUp]
        public void Given()
        {
            sut = A.Fake<YouCannotFakeASealedClass>();
            sut.DoSomething();
        }

        [Test]
        public void YouWillGetAnException()
        {
            A.CallTo(() => sut.DoSomething()).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
