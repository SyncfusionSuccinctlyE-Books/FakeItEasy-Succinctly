using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.DoingNothing
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
