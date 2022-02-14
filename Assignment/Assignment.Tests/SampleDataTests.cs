using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_GetData_ReturnNotNull()
        {
            SampleData data = new SampleData();
            Assert.IsNotNull(data.CsvRows);
        }

        [TestMethod]
        public void CsvRows_SkipFirst_ReturnCount()
        {
            IEnumerable<string> temp = new SampleData().CsvRows;
            Assert.AreEqual(50, temp.Count());
        }
        [TestMethod]
        public void GetUniqueSortedListOfState_AscendingOrder_ReturnTrue()
        {
            IEnumerable<string> temp = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows();
            var ascOrder = temp.OrderBy(x => x);
            Assert.IsTrue(temp.SequenceEqual(ascOrder));
        }
    }
}
