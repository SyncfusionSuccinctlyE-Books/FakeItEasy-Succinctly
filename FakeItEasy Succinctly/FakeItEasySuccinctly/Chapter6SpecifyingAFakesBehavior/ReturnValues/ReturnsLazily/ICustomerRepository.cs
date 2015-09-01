namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.ReturnValues.ReturnsLazily
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);
    }
}