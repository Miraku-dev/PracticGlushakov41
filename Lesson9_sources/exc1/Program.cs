Console.WriteLine("Введите вашу фамилию:");
string surname = Console.ReadLine();
Console.WriteLine("Введите ваши инициалы:");
string initials = Console.ReadLine();

string fileName = $"{surname.ToLower()}.{initials.ToLower()}";
string renamedFileName = $"{surname.ToLower()}.io";

// 1
File.WriteAllText(fileName, "Пример текста для файла");
Console.WriteLine("Содержимое файла:");
Console.WriteLine(File.ReadAllText(fileName));

// 2
if (File.Exists(fileName))
{
    File.Delete(fileName);
    Console.WriteLine("Файл удален");
}

// 3
File.WriteAllText(fileName, "Текст для проверки");
var fileInfo = new FileInfo(fileName);
Console.WriteLine($"Размер: {fileInfo.Length} байт");
Console.WriteLine($"Создан: {fileInfo.CreationTime}");
Console.WriteLine($"Изменен: {fileInfo.LastWriteTime}");

// 4
string copyName = $"{fileName}.copy";
File.Copy(fileName, copyName);
Console.WriteLine($"Копия существует: {File.Exists(copyName)}");

// 5
string newDir = "new_directory";
Directory.CreateDirectory(newDir);
string newPath = Path.Combine(newDir, fileName);
File.Move(fileName, newPath);
Console.WriteLine($"Файл перемещен: {File.Exists(newPath)}");

// 6
string renamedPath = Path.Combine(newDir, renamedFileName);
File.Move(newPath, renamedPath);
Console.WriteLine($"Файл переименован: {File.Exists(renamedPath)}");

// 7
try
{
    File.Delete("несуществующий_файл.txt");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Ошибка: Файл не найден");
}

// 8
File.WriteAllText("file1.txt", "Файл 1");
File.WriteAllText("file2.txt", "Файл 2");
Console.WriteLine($"Файлы одинакового размера: {new FileInfo("file1.txt").Length == new FileInfo("file2.txt").Length}");

// 9
File.WriteAllText("temp.ii", "Временный файл");
foreach (string file in Directory.GetFiles(".", "*.ii"))
    File.Delete(file);
Console.WriteLine("Файлы .ii удалены");

// 10
Console.WriteLine("Файлы в текущей директории:");
foreach (string file in Directory.GetFiles("."))
    Console.WriteLine(Path.GetFileName(file));

// 11
File.SetAttributes(renamedPath, FileAttributes.ReadOnly);
try
{
    File.AppendAllText(renamedPath, "Новый текст");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Запись запрещена (атрибут ReadOnly)");
}

// 12
try
{
    using (FileStream fs = File.Open(renamedPath, FileMode.Open, FileAccess.Read))
    {
        Console.WriteLine("\nПрава доступа:");
        Console.WriteLine("Чтение: разрешено");
    }
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("\nПрава доступа:");
    Console.WriteLine("Чтение: запрещено");
}

try
{
    using (FileStream fs = File.Open(renamedPath, FileMode.Open, FileAccess.Write))
    {
        Console.WriteLine("Запись: разрешена");
    }
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Запись: запрещена");
}