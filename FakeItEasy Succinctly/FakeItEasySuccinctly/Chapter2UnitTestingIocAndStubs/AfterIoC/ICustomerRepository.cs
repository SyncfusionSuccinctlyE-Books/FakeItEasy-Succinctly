namespace FakeItEasySuccinctly.Chapter2UnitTestingIocAndStubs.AfterIoC
{
    public interface ICustomerRepository
    {
        Customer GetCustomerBy(int customerId);
    }
}