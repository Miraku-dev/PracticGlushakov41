string filePath = "C:/Users/stali/source/repos/Practic10/exc2/bin/Debug/net8.0/file.data";

PersonFileReader reader = new();
List<Person> people = reader.ReadPeople(filePath);

PersonProcessor processor = new();
var groupedPeople = processor.GroupByAge(people);

foreach (var group in groupedPeople)
{
    Console.WriteLine($"Группа: {group.Key}");
    foreach (var person in group)
    {
        Console.WriteLine($"  {person.Name}, {person.Age} лет");
    }
}

public class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class PersonFileReader
{
    public List<Person> ReadPeople(string filePath)
    {
        List<Person> people = new();

        foreach (string line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split(',');
            string name = parts[0];
            int age = int.Parse(parts[1]);
            people.Add(new Person(name, age));
        }

        return people;
    }
}

public class PersonProcessor
{
    public IEnumerable<IGrouping<string, Person>> GroupByAge(List<Person> people)
    {
        return people
            .OrderBy(p => p.Age)
            .GroupBy(p =>
                p.Age < 18 ? "Моложе 18" :
                p.Age <= 40 ? "От 18 до 40" :
                "Старше 40");
    }
}