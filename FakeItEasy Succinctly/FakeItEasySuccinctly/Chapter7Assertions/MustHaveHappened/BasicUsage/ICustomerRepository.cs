using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter7Assertions.MustHaveHappened.BasicUsage
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
