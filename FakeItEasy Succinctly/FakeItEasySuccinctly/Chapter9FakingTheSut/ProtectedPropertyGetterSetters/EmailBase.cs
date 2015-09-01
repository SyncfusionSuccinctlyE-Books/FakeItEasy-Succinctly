using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter9FakingTheSut.ProtectedPropertyGetterSetters
{
    public abstract class EmailBase
    {
        private readonly ISendEmail emailProvider;

        protected EmailBase(ISendEmail emailProvider)
        {
            this.emailProvider = emailProvider;
        }

        protected void SendEmailToCustomers(string subject, string body, IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                emailProvider.SendMail(FromEmailAddress, customer.Email, subject, body);
            }
        }

        protected abstract string FromEmailAddress { get; }
    }
}
