namespace FakeItEasySuccinctly.Chapter9FakingTheSut.ProtectedPropertyGetterSetters
{
    public interface ISendEmail
    {
        void SendMail(string from, string to, string subject, string body);
    }
}
