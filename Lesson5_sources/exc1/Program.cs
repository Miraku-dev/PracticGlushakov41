Console.WriteLine("Введите количество транспортных средств:");
int count = int.Parse(Console.ReadLine() ?? "0");

Transport[] transports = new Transport[count];

for (int i = 0; i < count; i++)
{
    Console.WriteLine($"Выберите тип транспорта {i + 1} (1 - Car, 2 - Bike, 3 - Airplane):");
    int choice = int.Parse(Console.ReadLine() ?? "0");

    transports[i] = choice switch
    {
        1 => new Car(),
        2 => new Bike(),
        3 => new Airplane(),
        _ => throw new ArgumentException("Неверный выбор")
    };
}

foreach (var transport in transports)
{
    transport.Move();
}

abstract class Transport
{
    public abstract void Move();
}

class Car : Transport
{
    public override void Move()
    {
        Console.WriteLine("Машина едет по дороге");
    }
}

class Bike : Transport
{
    public override void Move()
    {
        Console.WriteLine("Велосипед едет по тротуару");
    }
}

class Airplane : Transport
{
    public override void Move()
    {
        Console.WriteLine("Самолет летит в небе");
    }
}