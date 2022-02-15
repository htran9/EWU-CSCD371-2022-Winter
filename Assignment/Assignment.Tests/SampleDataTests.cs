﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            IEnumerable<string> temp2 = new SampleData().CsvRows.Select(line => line.Split(',')).Select(x => x[6]).OrderBy(x => x).Distinct();
            Assert.IsTrue(temp.SequenceEqual(temp2));

        }
        [TestMethod]
        public void GetAggregateSortedList_ConvertToString_Success()
        {
            string tempString = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
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
            IEnumerable<string> temp = sampleData.CsvRows.OrderBy(state => state[6]).ThenBy(city => city[5]).ThenBy(zip => zip[7]);
            IEnumerable<string> people = sampleData.People.Cast<string>();


        }
        [TestMethod]
        public void People_FilterByEmail_ReturnFirstLastName()
        {
            SampleData sampleData = new SampleData();
            Predicate<string> filter = email;
            static bool email(string email) => email.Contains("pjenyns0@state.gov");
            IEnumerable<(string, string)> result = sampleData.FilterByEmailAddress(filter);
            
            var temp = ("Priscilla", "Jenyns");
            Console.WriteLine(result.First().Item1);

            Assert.AreEqual(temp, (result.First().Item1, result.First().Item2));
        }
    }
}
