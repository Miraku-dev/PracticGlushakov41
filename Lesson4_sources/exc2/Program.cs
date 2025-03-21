Console.WriteLine("Введите пять целых положительных чисел (каждое число с новой строки):");
int[] numbers = new int[5];

for (int i = 0; i < 5; i++)
{
    Console.Write($"Число {i + 1}: ");
    numbers[i] = int.Parse(Console.ReadLine() ?? "0");
}

foreach (var number in numbers)
{
    DigitCountSum(number, out int count, out int sum);
    Console.WriteLine($"Число: {number}, Количество цифр: {count}, Сумма цифр: {sum}");
}

static void DigitCountSum(int K, out int C, out int S)
{
    C = 0;
    S = 0;

    while (K > 0)
    {
        S += K % 10;
        K /= 10;
        C++;
    }
}