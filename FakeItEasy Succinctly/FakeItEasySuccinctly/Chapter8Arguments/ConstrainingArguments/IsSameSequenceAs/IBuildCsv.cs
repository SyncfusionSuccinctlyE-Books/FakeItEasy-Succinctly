using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter8Arguments.ConstrainingArguments.IsSameSequenceAs
{
    public interface IBuildCsv
    {
        void SetHeader(IEnumerable<string> fields);
        void AddRow(IEnumerable<string> fields);
        string Build();
    }
}
