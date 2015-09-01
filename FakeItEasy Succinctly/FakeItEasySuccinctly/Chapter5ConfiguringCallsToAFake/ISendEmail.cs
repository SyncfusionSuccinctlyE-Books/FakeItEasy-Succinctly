namespace FakeItEasySuccinctly.Chapter5ConfiguringCallsToAFake
{
    public interface ISendEmail
    {
        string GetEmailServerAddress();
        bool BodyIsHtml { get; set; }
        void SendMail();
    }
}