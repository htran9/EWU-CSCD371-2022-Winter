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
            IEnumerable<string> temp = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            string s = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            IEnumerable<IPerson> people = sampleData.People;
            //IEnumerable<string> csv = sampleData.CsvRows.SelectSelectMany()
            Predicate<string> filter = email;
            static bool email(string email) => email.Contains("cstnine2@wired.com");
            IEnumerable<(string, string)> result = sampleData.FilterByEmailAddress(filter);
            //Console.WriteLine(result.First());
            Console.WriteLine(sampleData.GetAggregateListOfStatesGivenPeopleCollection(people));
          
            /*foreach (var item in people)
            {
                Console.WriteLine(item.FirstName + "," + item.LastName + "," + item.EmailAddress + "," + item.Address.StreetAddress
                    + "," + item.Address.City + "," + item.Address.State + "," + item.Address.Zip);
            }*/
            /*  foreach (var item in people)
              {
                  Console.WriteLine(item);
              }*/
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
                Zip = int.Parse(items[7]) })
            .Select(items => $"{ items.Id }, { items.FirstName }, { items.LastName }, { items.Email }, " +
                $"{ items.StreetAddress }, { items.City }, { items.State }, { items.Zip }");

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            return CsvRows.Select(line => line.Split(',')).Select(x => x[6]).OrderBy(x => x).Distinct();
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string[] state = GetUniqueSortedListOfStatesGivenCsvRows().Select(x => x).ToArray();
            return string.Join(",", state);
        }

        // 4.
        // -----Not yet tested-----. 
        public IEnumerable<IPerson> People => CsvRows.Select(line => line.Split(',')).OrderBy(state => state[6]).ThenBy(city => city[5]).ThenBy(zip => zip[7])
            .Select(person => new Person(person[1], person[2], new Address(person[4], person[5], person[6], person[7]), person[3])).ToList();



        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            
            IEnumerable<IPerson> people = new SampleData().People;
            IEnumerable<(string FirstName, string LastName)> result = people.Where(x => filter(x.EmailAddress)).Select(name => (first: name.FirstName.Trim(), last: name.LastName.Trim())).ToList();
            return result;
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            string uniqueStateFromPeople = people.Select(x => x.Address.State).Distinct().Aggregate((a, b) => a + ',' + b);
            return uniqueStateFromPeople;
        }
    }
}
