Console.Write("Введите значение x: ");
double x = double.Parse(Console.ReadLine());
double y;

if (x > 1)
{
    y = Math.Log(2 * x) + Math.Sqrt(1 + Math.Pow(x, 2));
}
else
{
    y = 2 * Math.Cos(x) + 3 * Math.Pow(x, 2);
}

Console.WriteLine($"y = {y}");