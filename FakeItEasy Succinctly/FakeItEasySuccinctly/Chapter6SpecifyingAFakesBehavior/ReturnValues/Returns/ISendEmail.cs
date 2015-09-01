using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.ReturnValues.Returns
{
    public interface ISendEmail
    {
        string GetEmailServerAddress();
        List<string> GetAllCcRecipients();
    }
}
