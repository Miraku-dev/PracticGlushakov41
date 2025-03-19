Console.Write("Введите строку: ");
string input = Console.ReadLine();

Console.Write("Введите слово для замены: ");
string oldWord = Console.ReadLine();

Console.Write("Введите новое слово: ");
string newWord = Console.ReadLine();

var sb = new System.Text.StringBuilder(input);
sb.Replace(oldWord, newWord);

Console.WriteLine($"Результат: {sb.ToString()}");