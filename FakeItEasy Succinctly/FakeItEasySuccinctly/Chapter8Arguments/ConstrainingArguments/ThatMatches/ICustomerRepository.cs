using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter8Arguments.ConstrainingArguments.ThatMatches
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
