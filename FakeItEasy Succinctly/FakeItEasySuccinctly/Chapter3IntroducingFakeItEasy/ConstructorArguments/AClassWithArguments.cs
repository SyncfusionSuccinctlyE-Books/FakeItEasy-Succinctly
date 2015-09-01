using System;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter3IntroducingFakeItEasy.ConstructorArguments
{
    public class AClassWithArguments
    {
        private readonly string thisIsAnArgument;

        public AClassWithArguments(string thisIsAnArgument)
        {
            this.thisIsAnArgument = thisIsAnArgument;
        }

        public virtual void AFakeableMethod()
        {
            Console.Write(thisIsAnArgument);
        }
    }

    [TestFixture]
    public class WhenFakingAClassWithArgumentsUsingWithArgumentsForConstructor
    {
        private AClassWithArguments sut;

        [SetUp]
        public void Given()
        {
            sut = A.Fake<AClassWithArguments>(x => x.WithArgumentsForConstructor(() => new AClassWithArguments(A<string>.Ignored)));
            sut.AFakeableMethod();
        }

        [Test]
        public void ACallToAFakeableMethodMustHaveHappened()
        {
            A.CallTo(() => sut.AFakeableMethod()).MustHaveHappened();
        }
    }
}
