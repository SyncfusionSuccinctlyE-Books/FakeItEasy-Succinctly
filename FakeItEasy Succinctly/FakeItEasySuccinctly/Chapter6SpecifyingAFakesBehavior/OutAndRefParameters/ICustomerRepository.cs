using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.OutAndRefParameters
{
    public interface ICustomerRepository
    {
        void GetAllCustomers(out List<Customer> customers);
    }
}
