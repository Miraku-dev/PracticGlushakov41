int[] numbers = { 3, 7, 1, 9, 4, 6, 8, 2, 5 };
int D = 5;
int count = numbers.Count(x => x < D);
Console.WriteLine($"Количество чисел меньше {D}: {count}");

int[,] matrix = {
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};

int rows = matrix.GetLength(0);
int cols = matrix.GetLength(1);
double[] columnAverages = new double[cols];

for (int j = 0; j < cols; j++)
{
    int sum = 0;
    for (int i = 0; i < rows; i++)
    {
        sum += matrix[i, j];
    }
    columnAverages[j] = (double)sum / rows;
}

Console.WriteLine("Средние арифметические элементов столбцов:");
Console.WriteLine(string.Join(", ", columnAverages));

int[] array = { 9, 2, 5, 1, 7, 3, 8, 4, 6 };
Array.Sort(array);
Console.WriteLine("Отсортированный массив:");
Console.WriteLine(string.Join(", ", array));

Console.Write("Введите число k для поиска: ");
int k = int.Parse(Console.ReadLine());
int index = Array.BinarySearch(array, k);

if (index >= 0)
{
    Console.WriteLine($"Число {k} найдено на позиции {index}");
}
else
{
    Console.WriteLine($"Число {k} не найдено");
}