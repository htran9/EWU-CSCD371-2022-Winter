namespace Assignment
{
    public class SampleData : ISampleData
    {
  
        public static void Main(string[] args)
        {
            SampleData sampleData = new SampleData();
            ISampleData data = new SampleData();
            IEnumerable<string> temp = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            string s = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            IEnumerable<IPerson> people = sampleData.People;
            IEnumerable<string> csv = sampleData.CsvRows;
            Predicate<string> filter = email;
            static bool email(string email) => email.Contains("jdaneltim@jimdo.com");
            IEnumerable<(string, string)> result = sampleData.FilterByEmailAddress(filter);
           
            //Console.WriteLine(result.First());
            //Console.WriteLine(result.First());
            //Console.WriteLine(sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
            /*foreach (var item in people)
            {
                Console.WriteLine(item.FirstName + "," + item.LastName + "," + item.EmailAddress + "," + item.Address.StreetAddress
                    + "," + item.Address.City + "," + item.Address.State + "," + item.Address.Zip);
            }*/
            //List<string> tempList = sampleData.CsvRows.ToList();
            //Console.WriteLine(tempList[1]);
           /* foreach (var item in people1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------------------");
            foreach (var item in temptest)
            {
                Console.WriteLine(item);
            }*/

        }// END MAIN

        // maybe change the way the filepath is found
        // system.reflection.assembly.getexecutingassembly().Location
        // 1.
        private readonly Lazy<IEnumerable<string>> _LazyCsvRows = new Lazy<IEnumerable<string>>(() => File.ReadLines(@"People.csv").Where(line => !string.IsNullOrWhiteSpace(line)).Skip(1).Select(line => line));
        public IEnumerable<string> CsvRows { get { return _LazyCsvRows.Value; }}
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
        public IEnumerable<IPerson> People => _LazyCsvRows.Value.Select(line => line.Split(',')).OrderBy(state => state[6]).ThenBy(city => city[5]).ThenBy(zip => zip[7])
            .Select(person => new Person(person[1], person[2], new Address(person[4], person[5], person[6], person[7]), person[3]));

        
        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {

            IEnumerable<IPerson> people = new SampleData().People;
            IEnumerable<(string FirstName, string LastName)> result = people.Where(x => filter(x.EmailAddress)).Select(name => (first: name.FirstName.Trim(), last: name.LastName.Trim()));
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
