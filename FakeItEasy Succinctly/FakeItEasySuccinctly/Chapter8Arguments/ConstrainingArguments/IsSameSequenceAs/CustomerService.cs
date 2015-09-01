using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter8Arguments.ConstrainingArguments.IsSameSequenceAs
{
    public class CustomerService
    {
        private readonly IBuildCsv buildCsv;

        public CustomerService(IBuildCsv buildCsv)
        {
            this.buildCsv = buildCsv;
        }

        public string GetLastAndFirstNamesAsCsv(List<Customer> customers)
        {
            buildCsv.SetHeader(new[] { "Last Name", "First Name" });
            customers.ForEach(customer => buildCsv.AddRow(new [] { customer.LastName, customer.FirstName }));
            return buildCsv.Build();
        }
    }
}
