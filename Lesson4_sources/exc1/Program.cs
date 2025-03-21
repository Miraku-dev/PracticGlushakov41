Console.WriteLine("Введите число:");
int number = int.Parse(Console.ReadLine() ?? "0");

string binary = NumberConverter.ConvertToBinary(number);
Console.WriteLine($"Двоичное представление: {binary}");

static class NumberConverter
{
    public static string ConvertToBinary(int number)
    {
        return Convert.ToString(number, 2);
    }
}