namespace FakeItEasySuccinctly.Chapter2UnitTestingIocAndStubs.FakeItEasy
{
    public interface ICustomerRepository
    {
        Customer GetCustomerBy(int customerId);
    }
}