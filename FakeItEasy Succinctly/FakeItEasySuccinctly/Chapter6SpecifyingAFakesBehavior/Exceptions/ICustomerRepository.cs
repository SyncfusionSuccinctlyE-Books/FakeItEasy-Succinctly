using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.Exceptions
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
