Console.Write("Введите значение a: ");
int a = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Введите значение b: ");
int b = int.Parse(Console.ReadLine() ?? "0");

A obj = new A(a, b);

Console.WriteLine($"Среднее арифметическое: {obj.CalculateAverage()}");
Console.WriteLine($"Значение выражения b^3 + sqrt(a): {obj.CalculateExpression()}");

class A
{
    public int ValueA { get; set; }
    public int ValueB { get; set; }

    public A(int a, int b)
    {
        ValueA = a;
        ValueB = b;
    }

    public double CalculateAverage()
    {
        return (ValueA + ValueB) / 2.0;
    }

    public double CalculateExpression()
    {
        return Math.Pow(ValueB, 3) + Math.Sqrt(ValueA);
    }
}