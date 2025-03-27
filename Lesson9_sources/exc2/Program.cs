List<Person> people = new();

Console.WriteLine("Введите количество людей:");
int count = int.Parse(Console.ReadLine()!);

for (int i = 0; i < count; i++)
{
    Console.WriteLine($"Введите имя человека {i + 1}:");
    string name = Console.ReadLine()!;
    
    Console.WriteLine($"Введите возраст человека {i + 1}:");
    int age = int.Parse(Console.ReadLine()!);
    
    people.Add(new Person(name, age));
}

PersonFileSplitter splitter = new();
splitter.WritePeople(people);

string filePath = "file.data";
File.WriteAllLines(filePath, people.Select(p => $"{p.Name},{p.Age}"));

PersonFileReader reader = new();
List<Person> loadedPeople = reader.ReadPeople(filePath);

PersonProcessor processor = new();
var groupedPeople = processor.GroupByAge(loadedPeople);

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

public class PersonFileSplitter
{
    public void WritePeople(List<Person> people)
    {
        var adults = people.Where(p => p.Age >= 18).OrderBy(p => p.Age);
        var minors = people.Where(p => p.Age < 18).OrderBy(p => p.Age);

        WriteToFile("adults.data", adults);
        WriteToFile("minors.data", minors);
    }

    private void WriteToFile(string fileName, IEnumerable<Person> people)
    {
        using StreamWriter writer = new(fileName);
        foreach (var person in people)
        {
            writer.WriteLine($"{person.Name},{person.Age}");
        }
    }
}

public class PersonFileReader
{
    public List<Person> ReadPeople(string filePath)
    {
        return File.ReadAllLines(filePath)
            .Select(line => line.Split(','))
            .Select(parts => new Person(parts[0], int.Parse(parts[1])))
            .ToList();
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