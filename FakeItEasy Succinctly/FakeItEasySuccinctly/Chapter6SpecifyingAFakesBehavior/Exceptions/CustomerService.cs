namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.Exceptions
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
            try
            {
                emailSender.SendMail(customers);
            }
            catch (BadCustomerEmailException ex)
            {
                //do something here like write to a log file, etc...
            }
        }
    }
}