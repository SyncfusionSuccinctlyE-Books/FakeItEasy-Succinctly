namespace FakeItEasySuccinctly.Chapter8Arguments.ConstrainingArguments.ThatMatches
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
                emailSender.SendMail(new Email { From = "acompany@somewhere.com", To = customer.Email, Subject = "subject", Body = "body" });
            }
        }
    }
}
