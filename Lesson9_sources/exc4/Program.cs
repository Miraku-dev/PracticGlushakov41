string folderPath = ".";
FileWatcher watcher = new(folderPath);
Console.WriteLine($"Наблюдение за папкой: {Path.GetFullPath(folderPath)}");
Console.WriteLine("Нажмите любую клавишу для выхода...");
Console.ReadKey();

public class FileWatcher
{
    private readonly FileSystemWatcher _watcher;

    public FileWatcher(string folderPath)
    {
        _watcher = new FileSystemWatcher
        {
            Path = folderPath,
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
            Filter = "*.*"
        };

        _watcher.Created += OnCreated;
        _watcher.EnableRaisingEvents = true;
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Отправка email-уведомления: Обнаружен новый файл {e.Name}");
        Console.WriteLine($"Файл: {e.FullPath}");
        Console.WriteLine($"Время изменения: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine("----------------------------------");
    }
}