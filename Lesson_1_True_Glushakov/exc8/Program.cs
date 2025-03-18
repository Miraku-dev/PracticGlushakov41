Console.Write("Введите вещественное число A: ");
double A = double.Parse(Console.ReadLine());

Console.Write("Введите целое число N (> 0): ");
int N = int.Parse(Console.ReadLine());

double sum = 0;
double power = 1;

for (int i = 0; i <= N; i++)
{
    sum += power;
    power *= A;
}

Console.WriteLine($"Сумма: {sum}");