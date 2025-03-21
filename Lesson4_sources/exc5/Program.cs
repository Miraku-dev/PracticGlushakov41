Console.WriteLine("Выберите устройство (1 - Smartphone, 2 - Laptop):");
int choice = int.Parse(Console.ReadLine() ?? "0");

Device device = choice == 1 ? new Smartphone() : new Laptop();
device.TurnOn();
device.TurnOff();

abstract class Device
{
    public abstract void TurnOn();
    public virtual void TurnOff()
    {
        Console.WriteLine("Device is turning off");
    }
}

class Smartphone : Device
{
    public override void TurnOn()
    {
        Console.WriteLine("Smartphone is turning on");
    }

    public override void TurnOff()
    {
        Console.WriteLine("Smartphone is turning off");
    }
}

class Laptop : Device
{
    public override void TurnOn()
    {
        Console.WriteLine("Laptop is turning on");
    }

    public override void TurnOff()
    {
        Console.WriteLine("Laptop is turning off");
    }
}