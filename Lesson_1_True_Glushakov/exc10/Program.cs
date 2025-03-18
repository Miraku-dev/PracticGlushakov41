Console.Write("Введите число: ");
string input = Console.ReadLine();
string result = "";

foreach (char c in input)
{
    int digit = c - '0';
    if (digit % 2 != 0)
    {
        result += c;
    }
}

Console.WriteLine($"Результат: {result}");