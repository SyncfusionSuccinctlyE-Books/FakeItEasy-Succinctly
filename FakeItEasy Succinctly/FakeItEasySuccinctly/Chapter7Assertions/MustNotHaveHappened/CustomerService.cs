namespace FakeItEasySuccinctly.Chapter7Assertions.MustNotHaveHappened
{
    public class CustomerService
    {
        private readonly ISendEmail emailSender;
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ISendEmail emailSender, ICustomerRepository customerRepository)
        {
            this.emailSender = emailSender;
            this.customerRepository = customerRepository;
        }

        public void SendEmailToAllCustomers()
        {
            var customers = customerRepository.GetAllCustomers();
            foreach (var customer in customers)
            {
                emailSender.SendMail();
            }
        }
    }
}
