using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Introduction
{
    public interface IDoSomething
    {
        string DoIt();
    }

    public class ClassToBeTested
    {
        private readonly IDoSomething doSomething;

        public ClassToBeTested(IDoSomething doSomething)
        {
            this.doSomething = doSomething;
        }

        public string GoAheadAndDoIt()
        {
            return doSomething.DoIt();
        }
    }

    public static class ClassToBeTestedTests
    {
        [TestFixture]
        public class WhenTheClassToBeTestedIsDoingSomething
        {
            [SetUp]
            public void Given()
            {
                var sut = new ClassToBeTested(A.Fake<IDoSomething>());
            }
        }
    }
}
