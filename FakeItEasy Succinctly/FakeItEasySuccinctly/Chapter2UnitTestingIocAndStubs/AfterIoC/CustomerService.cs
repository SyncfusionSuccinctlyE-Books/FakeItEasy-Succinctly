namespace FakeItEasySuccinctly.Chapter2UnitTestingIocAndStubs.AfterIoC
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
