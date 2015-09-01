using System.Text;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.ReturnValues.ReturnsLazily
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public string GetCustomerNamesAsCsv(int[] customerIds)
        {
            var customers = new StringBuilder();
            foreach (var customerId in customerIds)
            {
                var customer = customerRepository.GetCustomerById(customerId);
                customers.Append(string.Format("{0} {1},", customer.FirstName, customer.LastName));
            }
            RemoveTrailingComma(customers);
            return customers.ToString();
        }

        private static void RemoveTrailingComma(StringBuilder stringBuilder)
        {
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }
    }
}