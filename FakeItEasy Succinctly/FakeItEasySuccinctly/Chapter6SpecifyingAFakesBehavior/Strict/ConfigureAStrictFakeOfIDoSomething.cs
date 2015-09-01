using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.Strict
{
    [TestFixture]
    public class ConfigureAStrictFakeOfIDoSomething
    {
        [SetUp]
        public void Given()
        {
            var doSomething = A.Fake<IDoSomething>(x => x.Strict());
            A.CallTo(() => doSomething.DoSomething()).Returns("I did it!");
            
            var sut = new AClassThatNeedsToDoSomething(doSomething);
            var result = sut.DoSomethingElse();
        }

        [Test]
        public void TestIt()
        {
        }
    }
}
