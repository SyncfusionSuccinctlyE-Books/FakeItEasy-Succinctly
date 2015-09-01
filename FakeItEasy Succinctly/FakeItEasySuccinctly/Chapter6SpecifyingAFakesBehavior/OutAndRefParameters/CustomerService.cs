using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.OutAndRefParameters
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
            List<Customer> customers;
            customerRepository.GetAllCustomers(out customers);
            foreach (var customer in customers)
            {
                emailSender.SendMail();
            }
        }
    }
}
