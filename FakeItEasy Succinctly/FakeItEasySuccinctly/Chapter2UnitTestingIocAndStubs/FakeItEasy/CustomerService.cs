namespace FakeItEasySuccinctly.Chapter2UnitTestingIocAndStubs.FakeItEasy
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer GetCustomerByCustomerId(int customerId)
        {
            return customerRepository.GetCustomerBy(customerId);
        }
    }
}
