Console.Write("Введите N (N<10): ");
int N = int.Parse(Console.ReadLine());

Console.Write("Введите a: ");
int a = int.Parse(Console.ReadLine());

Console.Write("Введите b: ");
int b = int.Parse(Console.ReadLine());

Console.Write("Введите D: ");
int D = int.Parse(Console.ReadLine());

Random rand = new Random();
int[,] matrix = new int[N, N];

Console.WriteLine("Исходная матрица:");
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        matrix[i, j] = rand.Next(a, b + 1);
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}

int count = 0;
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        if (matrix[i, j] < D) count++;
    }
}
Console.WriteLine($"Количество чисел, меньших {D}: {count}");

for (int j = 0; j < N; j++)
{
    double sum = 0;
    for (int i = 0; i < N; i++)
    {
        sum += matrix[i, j];
    }
    double average = sum / N;
    Console.WriteLine($"Среднее арифметическое столбца {j + 1}: {average}");
}