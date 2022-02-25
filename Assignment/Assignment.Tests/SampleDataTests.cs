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
        public void GetUniqueSortedListOfStatesGivenCsvRows_Spokane_IsEqual()
        {
            List<string> notAddSpokaneAddress = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            List<string> spokaneAddresses = sampleData.CsvRows.ToList();
            spokaneAddresses.Add(" , , , ,53 Grim Point,Spokane,WA,99022");
            spokaneAddresses.Add(" , , , ,601 E Riverside Ave,Spokane,WA 99202");
            spokaneAddresses.Add(" , , , ,1720 W 4th Ave Unit B,Spokane,WA 99201");
            List<string> listAfterAddingAddresses = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            Assert.IsTrue(notAddSpokaneAddress.SequenceEqual(listAfterAddingAddresses));
        }
        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_AscendingOrder_IsTrue()
        {
            IEnumerable<string> expected = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> result = sampleData.CsvRows.Select(line => line.Split(',')).Select(x => x[6]).OrderBy(x => x).Distinct();
            Assert.IsTrue(expected.SequenceEqual(result));

        }
        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ConvertToString_Success()
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
        public void AddressObjectCreated_NotNull()
        {
            Assert.IsNotNull(sampleData.People.First().Address);
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
        public void People_FilterByEmailAddress_ReturnFirstLastName()
        {
            Predicate<string> filter = email;
            static bool email(string email) => email.Contains("pjenyns0@state.gov");
            IEnumerable<(string, string)> result = sampleData.FilterByEmailAddress(filter);

            var temp = ("Priscilla", "Jenyns");
            Assert.AreEqual(temp, (result.First().Item1, result.First().Item2));
        }
        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollection_EqualTo_GetUniqueListGivenCsvRows_IsTrue()
        {
            string uniqueListCsvRows = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string aggregatedListPeople = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);
            Assert.IsTrue(uniqueListCsvRows.Equals(aggregatedListPeople));
        }
    }
}
