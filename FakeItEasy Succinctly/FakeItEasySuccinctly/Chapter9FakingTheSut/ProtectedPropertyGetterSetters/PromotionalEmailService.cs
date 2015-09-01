namespace FakeItEasySuccinctly.Chapter9FakingTheSut.ProtectedPropertyGetterSetters
{
    public class PromotionalEmailService : EmailBase
    {
        private readonly ICustomerRepository customerRepository;

        public PromotionalEmailService(ICustomerRepository customerRepository, ISendEmail emailProvider) : base(emailProvider)
        {
            this.customerRepository = customerRepository;
        }

        public void SendEmail(string subject, string body)
        {
            var customers = customerRepository.GetAllCustomersWithOrderTotalsOfOneHundredOrGreater();
            SendEmailToCustomers(subject, body, customers);
        }

        protected override string FromEmailAddress
        {
            get { return "APromotionalEmail@somecompany.com"; }
        }
    }
}
