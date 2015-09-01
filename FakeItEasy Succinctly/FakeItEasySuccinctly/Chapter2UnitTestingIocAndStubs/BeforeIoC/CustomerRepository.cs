namespace FakeItEasySuccinctly.Chapter2UnitTestingIocAndStubs.BeforeIoC
{
    public class CustomerRepository
    {
        public Customer GetCustomerBy(int customerId)
        {
            //this is where a call to the real database would be made
            return new Customer();
        }
    }
}
