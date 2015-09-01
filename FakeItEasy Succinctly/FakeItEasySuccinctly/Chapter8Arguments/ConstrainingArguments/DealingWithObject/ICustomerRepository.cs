using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter8Arguments.ConstrainingArguments.DealingWithObject
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
