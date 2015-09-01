using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter8Arguments.ConstrainingArguments.IsSameSequenceAs
{
    [TestFixture]
    public class WhenGettingCustomersLastAndFirstNamesAsCsv
    {
        private IBuildCsv buildCsv;
        private List<Customer> customers;

        [SetUp]
        public void Given()
        {
            buildCsv = A.Fake<IBuildCsv>();
            var sut = new CustomerService(buildCsv);
            customers = new List<Customer>
            {
                new Customer { LastName = "Doe", FirstName = "Jon"}, 
                new Customer { LastName = "McCarthy", FirstName = "Michael" }
            };
                
            sut.GetLastAndFirstNamesAsCsv(customers);
        }

        [Test]
        public void SetsCorrectHeader()
        {
            A.CallTo(() => buildCsv.SetHeader(A<IEnumerable<string>>.That.IsSameSequenceAs(new[] { "Last Name", "First Name" }))).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void AddsCorrectRows()
        {
            //A.CallTo(() => buildCsv.AddRow(A<IEnumerable<string>>.That.IsSameSequenceAs(new[] { customers[0].LastName, customers[0].FirstName }))).MustHaveHappened(Repeated.Exactly.Once);
            //A.CallTo(() => buildCsv.AddRow(A<IEnumerable<string>>.That.IsSameSequenceAs(new[] { customers[1].LastName, customers[1].FirstName }))).MustHaveHappened(Repeated.Exactly.Once);

            foreach (var customer in customers)
            {
                A.CallTo(() => buildCsv.AddRow(A<IEnumerable<string>>.That.IsSameSequenceAs(new[] { customer.LastName, customer.FirstName }))).MustHaveHappened(Repeated.Exactly.Once);
            }
        }

        [Test]
        public void AddRowsIsCalledForEachCustomer()
        {
            A.CallTo(() => buildCsv.AddRow(A<IEnumerable<string>>.Ignored)).MustHaveHappened(Repeated.Exactly.Times(customers.Count));
        }

        [Test]
        public void CsvIsBuilt()
        {
            A.CallTo(() => buildCsv.Build()).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}