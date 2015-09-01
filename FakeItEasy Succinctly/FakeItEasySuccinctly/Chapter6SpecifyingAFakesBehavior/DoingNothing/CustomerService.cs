namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.DoingNothing
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

        public void SendEmailToAllCustomersAsWellAsDoSomethingElse()
        {
            var customers = customerRepository.GetAllCustomers();
            foreach (var customer in customers)
            {
                //although this call is being made, we don't care about the setup, b/c it doesn't directly affect our results
                emailSender.SendMail();
            }
        }
    }
}
