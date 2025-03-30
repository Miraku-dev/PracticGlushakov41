Console.WriteLine("Выберите базовый автомобиль (1 - Седан, 2 - Внедорожник, 3 - Хэтчбек):");
int carType = int.Parse(Console.ReadLine() ?? "1");

ICar car = carType switch
{
    1 => new BasicCar("Седан", 10000),
    2 => new BasicCar("Внедорожник", 15000),
    3 => new BasicCar("Хэтчбек", 8000),
    _ => new BasicCar("Седан", 10000)
};

Console.WriteLine("Добавить люк? (1 - Да, 2 - Нет)");
if (Console.ReadLine() == "1") car = new SunroofDecorator(car);

Console.WriteLine("Добавить навигацию? (1 - Да, 2 - Нет)");
if (Console.ReadLine() == "1") car = new NavigationDecorator(car);

Console.WriteLine("Добавить кожаные сиденья? (1 - Да, 2 - Нет)");
if (Console.ReadLine() == "1") car = new LeatherSeatsDecorator(car);

Console.WriteLine($"\nКонфигурация автомобиля:\n{car.GetFeatures()}\nИтоговая цена: {car.GetPrice()}");

interface ICar
{
    string GetFeatures();
    double GetPrice();
}

class BasicCar : ICar
{
    private readonly string _type;
    private readonly double _basePrice;

    public BasicCar(string type, double basePrice)
    {
        _type = type;
        _basePrice = basePrice;
    }

    public string GetFeatures() => $"Базовый автомобиль ({_type})";
    public double GetPrice() => _basePrice;
}

abstract class CarDecorator : ICar
{
    protected ICar _car;

    protected CarDecorator(ICar car)
    {
        _car = car;
    }

    public virtual string GetFeatures() => _car.GetFeatures();
    public virtual double GetPrice() => _car.GetPrice();
}

class SunroofDecorator : CarDecorator
{
    public SunroofDecorator(ICar car) : base(car) { }

    public override string GetFeatures() => $"{_car.GetFeatures()}, с люком";
    public override double GetPrice() => _car.GetPrice() + 1500;
}

class NavigationDecorator : CarDecorator
{
    public NavigationDecorator(ICar car) : base(car) { }

    public override string GetFeatures() => $"{_car.GetFeatures()}, с навигацией";
    public override double GetPrice() => _car.GetPrice() + 800;
}

class LeatherSeatsDecorator : CarDecorator
{
    public LeatherSeatsDecorator(ICar car) : base(car) { }

    public override string GetFeatures() => $"{_car.GetFeatures()}, с кожаными сиденьями";
    public override double GetPrice() => _car.GetPrice() + 1200;
}