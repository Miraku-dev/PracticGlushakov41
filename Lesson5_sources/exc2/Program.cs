Console.WriteLine("Введите количество смартфонов:");
int count = int.Parse(Console.ReadLine() ?? "0");

Smartphone[] smartphones = new Smartphone[count];

for (int i = 0; i < count; i++)
{
    Console.WriteLine($"Введите имя пользователя для смартфона {i + 1}:");
    string userName = Console.ReadLine() ?? "Пользователь";

    Console.WriteLine($"Введите емкость батареи для смартфона {i + 1} (в мАч):");
    int batteryCapacity = int.Parse(Console.ReadLine() ?? "0");

    smartphones[i] = new Smartphone(new User(userName), new Battery(batteryCapacity));

    Console.WriteLine("Сколько приложений установить на этот смартфон?");
    int appCount = int.Parse(Console.ReadLine() ?? "0");

    for (int j = 0; j < appCount; j++)
    {
        Console.WriteLine($"Введите название приложения {j + 1}:");
        string appName = Console.ReadLine() ?? "Приложение";
        smartphones[i].InstallApp(new App(appName));
    }
}

foreach (var smartphone in smartphones)
{
    Console.WriteLine($"Смартфон пользователя {smartphone.Owner.Name}:");
    smartphone.ShowInstalledApps();
}

class User
{
    public string Name { get; }

    public User(string name)
    {
        Name = name;
    }
}

class Battery
{
    public int Capacity { get; }

    public Battery(int capacity)
    {
        Capacity = capacity;
    }
}

class App
{
    public string Name { get; }

    public App(string name)
    {
        Name = name;
    }
}

class Smartphone
{
    public User Owner { get; }
    public Battery Battery { get; }
    private List<App> Apps { get; } = new List<App>();

    public Smartphone(User owner, Battery battery)
    {
        Owner = owner;
        Battery = battery;
    }

    public void InstallApp(App app)
    {
        Apps.Add(app);
    }

    public void ShowInstalledApps()
    {
        Console.WriteLine($"Установленные приложения (Батарея: {Battery.Capacity} мАч):");
        foreach (var app in Apps)
        {
            Console.WriteLine($"- {app.Name}");
        }
    }
}