using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public static void Main(string[] args)
        {
            SampleData sampleData = new SampleData();
            //IEnumerable<string> temp = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            //Console.WriteLine(temp);


            foreach (var item in sampleData.GetUniqueSortedListOfStatesGivenCsvRows())
            {
                Console.WriteLine(item);
            }

        }
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines(@"People.csv").Where(line => !string.IsNullOrWhiteSpace(line)).Skip(1).Select(line => line.Split(','))
            .Select(items => new { 
                Id = int.Parse(items[0]),
                FirstName = items[1],
                LastName = items[2],
                Email = items[3],
                StreetAddress = items[4],
                City = items[5],
                State = items[6],
                Zip = int.Parse(items[7])})
            .Select(items => $"{ items.Id }, { items.FirstName }, { items.LastName }, { items.Email }, " +
                $"{ items.StreetAddress }, { items.City }, { items.State }, { items.Zip }");

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> distinctState = CsvRows.Where(line => !string.IsNullOrWhiteSpace(line)).Select(line => line.Split(','))
                .Select(x => x[6]).OrderBy(x => x).Distinct();
            return distinctState;
        }


// 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows() => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
