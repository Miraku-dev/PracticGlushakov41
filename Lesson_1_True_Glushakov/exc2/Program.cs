Console.Write("Введите целое число: ");
int number = int.Parse(Console.ReadLine());

bool isOddThreeDigitNumber = (number >= 100 && number <= 999) && (number % 2 != 0);

Console.WriteLine($"Число {number} является нечетным трехзначным: {isOddThreeDigitNumber}");