Console.Write("Введите целое число: ");
int number = int.Parse(Console.ReadLine());

bool endsWithSeven = number % 10 == 7;

Console.WriteLine(endsWithSeven ? "Число оканчивается на 7." : "Число не оканчивается на 7.");