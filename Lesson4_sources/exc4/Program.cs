Console.WriteLine("Введите дату рождения (в формате ГГГГ-ММ-ДД):");
DateTime birthDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());

int age = birthDate.CalculateAge();
Console.WriteLine($"Возраст: {age} лет");

static class DateTimeExtensions
{
    public static int CalculateAge(this DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }
}