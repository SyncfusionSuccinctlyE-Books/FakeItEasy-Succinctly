using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter9FakingTheSut
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomersWithOrderTotalsOfOneHundredOrGreater();
    }
}
