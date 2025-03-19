Console.Write("Введите строку: ");
string input = Console.ReadLine();

string upperCase = input.ToUpper();
string lowerCase = input.ToLower();

Console.WriteLine($"Верхний регистр: {upperCase}");
Console.WriteLine($"Нижний регистр: {lowerCase}");