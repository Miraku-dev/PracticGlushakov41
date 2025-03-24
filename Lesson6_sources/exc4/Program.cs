using System.IO;

Console.WriteLine("Введите путь к файлу для отслеживания:");
string filePath = Console.ReadLine() ?? "file.txt";

FileWatcher fileWatcher = new FileWatcher();
FileMonitor fileMonitor = new FileMonitor(fileWatcher);

fileWatcher.WatchFile(filePath);

class FileWatcher
{
    public event EventHandler<string> FileChanged;

    public void WatchFile(string filePath)
    {
        string directory = Path.GetDirectoryName(filePath) ?? ".";
        string fileName = Path.GetFileName(filePath);

        FileSystemWatcher watcher = new FileSystemWatcher
        {
            Path = directory,
            Filter = fileName,
            NotifyFilter = NotifyFilters.LastWrite
        };

        watcher.Changed += (sender, e) => FileChanged?.Invoke(this, e.FullPath);
        watcher.EnableRaisingEvents = true;

        Console.WriteLine($"Отслеживание файла: {filePath}");
    }
}

class FileMonitor
{
    private readonly BackupService _backupService = new BackupService();
    private readonly Logger _logger = new Logger();

    public FileMonitor(FileWatcher fileWatcher)
    {
        fileWatcher.FileChanged += _backupService.OnFileChanged;
        fileWatcher.FileChanged += _logger.OnFileChanged;
    }
}

class BackupService
{
    public void OnFileChanged(object sender, string filePath)
    {
        string backupPath = filePath + ".backup";
        File.Copy(filePath, backupPath, overwrite: true);
        Console.WriteLine($"Резервная копия файла {filePath} создана: {backupPath}");
    }
}

class Logger
{
    public void OnFileChanged(object sender, string filePath)
    {
        string logMessage = $"[{DateTime.Now}] Изменение файла: {filePath}";
        File.AppendAllText("log.txt", logMessage + Environment.NewLine);
        Console.WriteLine(logMessage);
    }
}