Console.Write("Введите строку: ");
string input = Console.ReadLine();

var charCounts = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

int oddCount = charCounts.Count(kvp => kvp.Value % 2 != 0);

bool canFormPalindrome = oddCount <= 1;

Console.WriteLine(canFormPalindrome ? "Можно получить палиндром." : "Нельзя получить палиндром.");