using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.ReturnValues.ReturnsNextFromSequence
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
    }
}
