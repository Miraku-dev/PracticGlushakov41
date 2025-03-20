Console.WriteLine("Введите размер массива:");
int size = int.Parse(Console.ReadLine() ?? "0");

Person[] persons = ArrayOperations.GenerateRandomPersons(size);

Console.WriteLine("Сгенерированные объекты:");
foreach (var person in persons)
{
    Console.WriteLine($"Имя: {person.Name}, Возраст: {person.Age}");
}

Console.WriteLine("\nОтсортированные по возрасту:");
var sortedPersons = ArrayOperations.SortByAge(persons);
foreach (var person in sortedPersons)
{
    Console.WriteLine($"Имя: {person.Name}, Возраст: {person.Age}");
}

Console.WriteLine("\nФильтрация по возрасту (старше 30):");
var filteredPersons = ArrayOperations.FilterByAge(persons, 30);
foreach (var person in filteredPersons)
{
    Console.WriteLine($"Имя: {person.Name}, Возраст: {person.Age}");
}

Console.WriteLine($"\nСредний возраст: {ArrayOperations.CalculateAverageAge(persons):F2}");

static class ArrayOperations
{
    private static Random random = new Random();

    public static Person[] GenerateRandomPersons(int size)
    {
        string[] names = { "Алексей", "Мария", "Иван", "Ольга", "Дмитрий", "Елена" };
        Person[] persons = new Person[size];

        for (int i = 0; i < size; i++)
        {
            string name = names[random.Next(names.Length)];
            int age = random.Next(18, 60);
            persons[i] = new Person(name, age);
        }

        return persons;
    }

    public static Person[] SortByAge(Person[] persons)
    {
        return persons.OrderBy(p => p.Age).ToArray();
    }

    public static Person[] FilterByAge(Person[] persons, int minAge)
    {
        return persons.Where(p => p.Age > minAge).ToArray();
    }

    public static double CalculateAverageAge(Person[] persons)
    {
        return persons.Average(p => p.Age);
    }
}

class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}