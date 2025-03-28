Console.WriteLine("Введите текст для форматирования:");
string inputText = Console.ReadLine()!;

Console.WriteLine("Выберите формат (1 - UpperCase, 2 - LowerCase, 3 - TitleCase):");
string choice = Console.ReadLine()!;

ITextFormatStrategy strategy = choice switch
{
    "1" => new UpperCaseFormat(),
    "2" => new LowerCaseFormat(),
    "3" => new TitleCaseFormat(),
    _ => throw new ArgumentException("Неверный выбор")
};

var formatter = new TextFormatter(strategy);
Console.WriteLine($"Результат: {formatter.FormatText(inputText)}");

public interface ITextFormatStrategy
{
    string Format(string text);
}

public class UpperCaseFormat : ITextFormatStrategy
{
    public string Format(string text) => text.ToUpper();
}

public class LowerCaseFormat : ITextFormatStrategy
{
    public string Format(string text) => text.ToLower();
}

public class TitleCaseFormat : ITextFormatStrategy
{
    public string Format(string text) => System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
}

public class TextFormatter
{
    private readonly ITextFormatStrategy _strategy;

    public TextFormatter(ITextFormatStrategy strategy)
    {
        _strategy = strategy;
    }

    public string FormatText(string text) => _strategy.Format(text);
}