using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter9FakingTheSut.ProtectedPropertyGetterSetters
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomersWithOrderTotalsOfOneHundredOrGreater();
    }
}
