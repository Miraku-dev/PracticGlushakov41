Console.WriteLine("Введите email для проверки:");
string email = Console.ReadLine() ?? string.Empty;

try
{
    EmailValidator validator = new EmailValidator();
    validator.ValidateEmail(email);
    Console.WriteLine("Email валиден.");
}
catch (InvalidEmailException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}

class InvalidEmailException : Exception
{
    public InvalidEmailException() : base("Некорректный формат email") { }
    public InvalidEmailException(string message) : base(message) { }
    public InvalidEmailException(string message, Exception inner) : base(message, inner) { }
}

class EmailValidator
{
    public void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.Contains('.'))
        {
            throw new InvalidEmailException($"'{email}' не является валидным email-адресом");
        }
    }
}