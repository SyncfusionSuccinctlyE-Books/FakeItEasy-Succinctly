using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.Invokes
{
    public interface IBuildCsv
    {
        void SetHeader(IEnumerable<string> fields);
        void AddRow(IEnumerable<string> fields);
        string Build();
    }
}
