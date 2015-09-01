namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.ReturnValues.ReturnsNextFromSequence
{
    public class CustomerService
    {
        private readonly ISendEmail emailSender;
        private readonly ICustomerRepository customerRepository;
        private readonly IProvideNewGuids guidProvider;

        public CustomerService(ISendEmail emailSender, ICustomerRepository customerRepository, IProvideNewGuids guidProvider)
        {
            this.emailSender = emailSender;
            this.customerRepository = customerRepository;
            this.guidProvider = guidProvider;
        }

        public void SendEmailToAllCustomers()
        {
            var customers = customerRepository.GetAllCustomers();
            foreach (var customer in customers)
            {
                var email = new Email { Id = guidProvider.GenerateNewId(), To = customer.Email };
                emailSender.SendMail(email);
            }
        }
    }
}
