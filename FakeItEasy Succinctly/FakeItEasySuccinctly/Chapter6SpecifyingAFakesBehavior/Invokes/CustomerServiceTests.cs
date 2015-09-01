using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;

namespace FakeItEasySuccinctly.Chapter6SpecifyingAFakesBehavior.Invokes
{
    public static class CustomerServiceTests
    {
        [TestFixture]
        public class WhenGettingCustomersLastAndFirstNamesAsCsv
        {
            private readonly string[] headerList = { "Last Name", "First Name" };
            private string[] bodyList;
            private string[] appendedHeaders;
            private string[] appendedRows;

            [SetUp]
            public void Given()
            {
                var buildCsv = A.Fake<IBuildCsv>();
                A.CallTo(() => buildCsv.SetHeader(A<IEnumerable<string>>.Ignored)).Invokes(x => appendedHeaders = (string[])x.Arguments.First());
                A.CallTo(() => buildCsv.AddRow(A<IEnumerable<string>>.Ignored)).Invokes(x => appendedRows = (string[])x.Arguments.First());
        
                var customers = new List<Customer> { new Customer { LastName = "Doe", FirstName = "Jon"} };
                bodyList = new[] { customers[0].LastName, customers[0].FirstName };

                var sut = new CustomerService(buildCsv);        
                sut.GetLastAndFirstNamesAsCsv(customers);
            }

            [Test]
            public void SetsCorrectHeader()
            {
                Assert.IsTrue(appendedHeaders.SequenceEqual(headerList));
            }

            [Test]
            public void AddsCorrectRows()
            {
                Assert.IsTrue(appendedRows.SequenceEqual(bodyList));
            }
        }
    }
}
