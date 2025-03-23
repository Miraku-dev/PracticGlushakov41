Console.WriteLine("Введите количество специалистов:");
int count = int.Parse(Console.ReadLine() ?? "0");

ITSpecialist[] specialists = new ITSpecialist[count];

for (int i = 0; i < count; i++)
{
    Console.WriteLine($"Выберите тип специалиста {i + 1} (1 - BackendDeveloper, 2 - UXDesigner):");
    int choice = int.Parse(Console.ReadLine() ?? "0");

    Console.WriteLine($"Введите имя специалиста {i + 1}:");
    string name = Console.ReadLine() ?? "Специалист";

    specialists[i] = choice switch
    {
        1 => new BackendDeveloper(name),
        2 => new UXDesigner(name),
        _ => throw new ArgumentException("Неверный выбор")
    };
}

Console.WriteLine("Программисты:");
foreach (var specialist in specialists.OfType<IProgrammer>())
{
    Console.WriteLine($"- {specialist.Name}");
    ((BackendDeveloper)specialist).WriteCode();
}

abstract class ITSpecialist
{
    public string Name { get; }

    protected ITSpecialist(string name)
    {
        Name = name;
    }
}

interface IProgrammer
{
    string Name { get; }
    void WriteCode();
}

interface IDesigner
{
    string Name { get; }
    void DesignUI();
}

class BackendDeveloper : ITSpecialist, IProgrammer
{
    public BackendDeveloper(string name) : base(name) { }

    public void WriteCode()
    {
        Console.WriteLine($"{Name} пишет код на C#");
    }
}

class UXDesigner : ITSpecialist, IDesigner
{
    public UXDesigner(string name) : base(name) { }

    public void DesignUI()
    {
        Console.WriteLine($"{Name} создает дизайн интерфейса");
    }
}