Console.WriteLine("Введите строку:");
string input = Console.ReadLine() ?? string.Empty;

string reversed = ReverseString(input);
Console.WriteLine($"Перевернутая строка: {reversed}");

static string ReverseString(string str)
{
    if (str.Length <= 1)
        return str;

    return str[^1] + ReverseString(str[..^1]);
}