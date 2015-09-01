using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter4CreatingAFake
{
    public interface IAmAnInterface
    {
        void DoSomething();
        string DoSomethingAndReturnAString();
        List<string> DoSomethingAndReturnAListOfString();
    }

    public class WhenFakingAnInterface
    {
        [SetUp]
        public void Given()
        {
            var aFakeInterface = A.Fake<IAmAnInterface>();
        }
    }

    public class AClass
    {
        public virtual void DoSomething()
        {
            //some implementation
        }
    }

    public class WhenFakingAClass
    {
        [SetUp]
        public void Given()
        {
            var aFakeClass = A.Fake<AClass>();
        }
    }
}