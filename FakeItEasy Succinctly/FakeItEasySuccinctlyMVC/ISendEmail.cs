namespace FakeItEasySuccinctlyMVC
{
    public interface ISendEmail
    {
        void SendEmailTo(string from, string to, string subject, string body);
    }
}