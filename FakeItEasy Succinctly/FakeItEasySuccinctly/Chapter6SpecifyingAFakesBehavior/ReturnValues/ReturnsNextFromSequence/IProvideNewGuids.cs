using System;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.ReturnValues.ReturnsNextFromSequence
{
    public interface IProvideNewGuids
    {
        Guid GenerateNewId();
    }
}
