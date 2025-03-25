Console.WriteLine("Введите текущую скорость автомобиля (км/ч):");
int speed = int.Parse(Console.ReadLine() ?? "0");

try
{
    Car car = new Car();
    car.SetSpeed(speed);
    Console.WriteLine("Скорость установлена успешно.");
}
catch (SpeedLimitExceededException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
}

class SpeedLimitExceededException : Exception
{
    public SpeedLimitExceededException() : base("Превышена максимальная скорость!") { }
    public SpeedLimitExceededException(string message) : base(message) { }
    public SpeedLimitExceededException(string message, Exception inner) : base(message, inner) { }
}

class Car
{
    private const int MaxSpeed = 120;

    public void SetSpeed(int speed)
    {
        if (speed > MaxSpeed)
        {
            throw new SpeedLimitExceededException($"Скорость {speed} км/ч превышает допустимый предел {MaxSpeed} км/ч");
        }
    }
}