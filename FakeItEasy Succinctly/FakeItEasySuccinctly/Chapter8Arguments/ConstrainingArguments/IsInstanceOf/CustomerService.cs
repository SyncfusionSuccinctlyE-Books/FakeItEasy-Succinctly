namespace FakeItEasySuccinctly.Chapter8Arguments.ConstrainingArguments.IsInstanceOf
{
    public class CustomerService
    {
        private readonly IBus bus;

        public CustomerService(IBus bus)
        {
            this.bus = bus;
        }

        public void CreateCustomer(string firstName, string lastName, string email)
        {
            bus.Send(new CreateCustomer { FirstName = firstName, LastName = lastName, Email = email });
        }
    }
}
