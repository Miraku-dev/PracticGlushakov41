Console.Write("Введите IP-адрес: ");
string input = Console.ReadLine();

var regex = new System.Text.RegularExpressions.Regex(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");

bool isValid = regex.IsMatch(input);

Console.WriteLine(isValid ? "Корректный IP-адрес." : "Некорректный IP-адрес.");