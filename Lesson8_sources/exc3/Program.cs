Console.WriteLine("Введите сообщение для лога:");
string message = Console.ReadLine() ?? "Default log message";

var loggerManager = new LoggerManager<string>(new ConsoleLogger<string>());
loggerManager.LogError(message);
loggerManager.LogWarning(message);

interface ILogger<T>
{
    void Log(T message);
}

class ConsoleLogger<T> : ILogger<T>
{
    public void Log(T message) => Console.WriteLine($"[LOG] {message}");
}

class LoggerManager<T>
{
    private readonly ILogger<T> _logger;

    public LoggerManager(ILogger<T> logger) => _logger = logger;

    public void LogError(T message) => _logger.Log(message);
    public void LogWarning(T message) => _logger.Log(message);
}