using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_GetData_NotNull()
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
        public void GetUniqueSortedListOfState_AscendingOrder_IsTrue()
        {
            IEnumerable<string> temp = new SampleData().GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> ascOrder = temp.OrderBy(x => x);
            Assert.IsTrue(temp.SequenceEqual(ascOrder));
           
        }
        [TestMethod]
        public void GetAggregateSortedList_ConvertToString_Success()
        {
            string tempString = " AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";
            string actualString = new SampleData().GetAggregateSortedListOfStatesUsingCsvRows();
            Assert.IsTrue(tempString.Equals(actualString));
        }
        [TestMethod]
        public void PeopleObjectCreated_NotNull()
        {
            SampleData sampleData = new SampleData();    
            Assert.IsNotNull(sampleData.People);
        }
        [TestMethod]
        public void PeopleObject_EqualTo_CsvRowsSorted_IsTrue()
        {
            SampleData sampleData = new SampleData();
            IEnumerable<string> temp = sampleData.CsvRows.OrderBy(state => state[6]).ThenBy(city => city[5]).ThenBy(zip => zip[7]).ToList();
            IEnumerable<IPerson> people = sampleData.People;
           
            
        }
    }
}
