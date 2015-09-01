using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter7Assertions.MustNotHaveHappened
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
