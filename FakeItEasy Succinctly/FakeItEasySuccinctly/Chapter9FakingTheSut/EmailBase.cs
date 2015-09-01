using System.Collections.Generic;
using System.Configuration;

namespace FakeItEasySuccinctly.Chapter9FakingTheSut
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
                emailProvider.SendMail(GetFromEmailAddress(), customer.Email, subject, body);
            }
        }

        protected virtual string GetFromEmailAddress()
        {
            return ConfigurationManager.AppSettings["DefaultFromAddress"];
        }
    }
}