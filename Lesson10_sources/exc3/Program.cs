Console.WriteLine("Введите режим (День/Ночь/Выходные):");
string mode = Console.ReadLine()!;

var hub = new SmartHomeHub();
var light = new Light();
var thermostat = new Thermostat();
var alarm = new Alarm();

hub.Subscribe(light);
hub.Subscribe(thermostat);
hub.Subscribe(alarm);

hub.SetMode(mode);

public interface IDevice
{
    void Update(string mode);
}

public class SmartHomeHub
{
    private readonly List<IDevice> _devices = new();
    private string _currentMode = "День";

    public void Subscribe(IDevice device) => _devices.Add(device);
    public void Unsubscribe(IDevice device) => _devices.Remove(device);

    public void SetMode(string mode)
    {
        _currentMode = mode;
        NotifyDevices();
    }

    private void NotifyDevices()
    {
        foreach (var device in _devices)
        {
            device.Update(_currentMode);
        }
    }
}

public class Light : IDevice
{
    public void Update(string mode)
    {
        string state = mode == "Ночь" ? "Включен ночной режим" : "Обычный режим";
        Console.WriteLine($"Свет: {state}");
    }
}

public class Thermostat : IDevice
{
    public void Update(string mode)
    {
        int temperature = mode switch
        {
            "Ночь" => 20,
            "День" => 22,
            "Выходные" => 24,
            _ => 22
        };
        Console.WriteLine($"Термостат: установлена температура {temperature}°C");
    }
}

public class Alarm : IDevice
{
    public void Update(string mode)
    {
        string state = mode == "Ночь" ? "Активирована" : "Деактивирована";
        Console.WriteLine($"Сигнализация: {state}");
    }
}