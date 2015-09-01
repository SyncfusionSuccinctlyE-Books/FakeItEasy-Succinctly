namespace FakeItEasySuccinctly.Chapter9FakingTheSut
{
    public class AdminEmailService : EmailBase
    {
        private readonly ICustomerRepository customerRepository;

        public AdminEmailService(ICustomerRepository customerRepository, ISendEmail emailProvider)
            : base(emailProvider)
        {
            this.customerRepository = customerRepository;
        }

        public void SendPromotionalEmail(string subject, string body)
        {
            var customers = customerRepository.GetAllCustomersWithOrderTotalsOfOneHundredOrGreater();
            SendEmailToCustomers(subject, body, customers);
        }
    }
}
