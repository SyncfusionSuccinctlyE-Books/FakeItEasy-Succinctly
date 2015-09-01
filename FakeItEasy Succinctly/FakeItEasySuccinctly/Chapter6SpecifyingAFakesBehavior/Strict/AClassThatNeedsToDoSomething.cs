namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.Strict
{
    public class AClassThatNeedsToDoSomething
    {
        private readonly IDoSomething doSomething;

        public AClassThatNeedsToDoSomething(IDoSomething doSomething)
        {
            this.doSomething = doSomething;
        }

        public string DoSomethingElse()
        {
            return doSomething.DoSomethingElse();
        }
    }
}
