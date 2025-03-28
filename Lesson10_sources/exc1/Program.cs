Console.WriteLine("Введите тему (Тёмная/Светлая):");
string inputTheme = Console.ReadLine()!;

UISettings.Instance.SetTheme(inputTheme);
Console.WriteLine($"Текущая тема: {UISettings.Instance.GetTheme()}");

public sealed class UISettings
{
    private static readonly UISettings _instance = new();
    private string _theme = "Светлая";

    private UISettings() { }

    public static UISettings Instance => _instance;

    public void SetTheme(string theme) => _theme = theme;
    public string GetTheme() => _theme;
}