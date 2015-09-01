using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter8Arguments.PassingArgumentsToMethods
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
