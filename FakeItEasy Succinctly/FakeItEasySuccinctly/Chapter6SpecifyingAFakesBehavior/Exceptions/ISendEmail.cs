using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.Exceptions
{
    public interface ISendEmail
    {
        void SendMail(List<Customer> customers);
    }
}