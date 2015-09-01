namespace FakeItEasySuccinctly.Chapter2UnitTestingIocAndStubs.AfterIoC
{
    public class CustomerRepositoryStub : ICustomerRepository
    {
        public Customer GetCustomerBy(int customerId)
        {
            return new Customer { Id = customerId };
        }
    }
}