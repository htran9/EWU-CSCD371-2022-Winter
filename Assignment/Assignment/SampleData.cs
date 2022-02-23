namespace Assignment;

public class SampleData : ISampleData
{


    // 1.
    private readonly Lazy<IEnumerable<string>> _LazyCsvRows = new Lazy<IEnumerable<string>>(
        () => File.ReadLines(@"People.csv").Where(line => !string.IsNullOrWhiteSpace(line)).Skip(1));
    public IEnumerable<string> CsvRows { get { return _LazyCsvRows.Value; } }


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
    public IEnumerable<IPerson> People => _LazyCsvRows.Value.Select(line => line.Split(','))
        .OrderBy(state => state[6])
            .ThenBy(city => city[5])
            .ThenBy(zip => zip[7])
        .Select(
            person => new Person(person[1], person[2],
            new Address(person[4], person[5], person[6], person[7]),
            person[3]));


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

