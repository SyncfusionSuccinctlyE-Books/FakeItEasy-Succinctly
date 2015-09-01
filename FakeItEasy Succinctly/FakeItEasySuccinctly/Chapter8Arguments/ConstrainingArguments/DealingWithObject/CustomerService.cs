namespace FakeItEasySuccinctly.Chapter8Arguments.ConstrainingArguments.DealingWithObject
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

        public void SendEmailToPreferredCustomers()
        {
            var customers = customerRepository.GetAllCustomers();
            foreach (var customer in customers)
                if (customer.IsPreferred)
                    emailSender.SendMail(new Email { EmailType = new PreferredCustomerEmail { Email = customer.Email }});
        }
    }
}
