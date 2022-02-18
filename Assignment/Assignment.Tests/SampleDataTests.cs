using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        SampleData sampleData = new SampleData();

        [TestMethod]
        public void CsvRows_GetData_NotNull()
        {
  
            Assert.IsNotNull(sampleData.CsvRows);
        }

        [TestMethod]
        public void CsvRows_SkipFirst_ReturnCount()
        {
            IEnumerable<string> temp = sampleData.CsvRows;
            Assert.AreEqual(50, temp.Count());
        }
        [TestMethod]
        public void CsvRows_CompareFirstLineWithoutSkip_IsFalse()
        {
            string beforeSkipFirstLine = "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip";
            string firstLineCsvRows = sampleData.CsvRows.First();
            Assert.IsFalse(beforeSkipFirstLine.Equals(firstLineCsvRows));
        }
        [TestMethod]
        public void GetUniqueSortedListOfState_AscendingOrder_IsTrue()
        {
            IEnumerable<string> temp = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> temp2 = sampleData.CsvRows.Select(line => line.Split(',')).Select(x => x[6]).OrderBy(x => x).Distinct();
            Assert.IsTrue(temp.SequenceEqual(temp2));

        }
        [TestMethod]
        public void GetAggregateSortedList_ConvertToString_Success()
        {
            string tempString = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
            string actualString = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            Assert.IsTrue(tempString.Equals(actualString));
        }
        [TestMethod]
        public void PeopleObjectCreated_NotNull()
        {
            Assert.IsNotNull(sampleData.People);
        }
        [TestMethod]
        public void PeopleObject_EqualTo_CsvRowsSorted_IsTrue()
        {
            IEnumerable<string> people = sampleData.People
                .Select(items => $"{ items.FirstName },{ items.LastName },{ items.EmailAddress },{ items.Address.StreetAddress }" +
                $",{ items.Address.City },{ items.Address.State },{ items.Address.Zip }");

            IEnumerable<string> csvSorted = sampleData.CsvRows.Select(line => line.Split(','))
                .Select(items => new {
                    FirstName = items[1],
                    LastName = items[2],
                    Email = items[3],
                    StreetAddress = items[4],
                    City = items[5],
                    State = items[6],
                    ZipCode = items[7],
                }).OrderBy(item => item.State).ThenBy(item => item.City).ThenBy(item => item.ZipCode)
                .Select(items => $"{ items.FirstName },{ items.LastName },{ items.Email },{ items.StreetAddress }" +
                $",{ items.City },{ items.State },{ items.ZipCode }");
            Assert.IsTrue(people.SequenceEqual(csvSorted));
        }
        [TestMethod]
        public void People_FilterByEmail_ReturnFirstLastName()
        {
            Predicate<string> filter = email;
            static bool email(string email) => email.Contains("pjenyns0@state.gov");
            IEnumerable<(string, string)> result = sampleData.FilterByEmailAddress(filter);

            var temp = ("Priscilla", "Jenyns");
            Console.WriteLine(result.First().Item1);

            Assert.AreEqual(temp, (result.First().Item1, result.First().Item2));
        }
        [TestMethod]
        public void GetAggregatedListGivenPeople_EqualTo_GetUniqueListGivenCsvRows_IsTrue()
        {
            string uniqueListCsvRows = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string aggregatedListPeople = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);
            Assert.IsTrue(uniqueListCsvRows.Equals(aggregatedListPeople));
        }
    }
}
