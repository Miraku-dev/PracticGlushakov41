Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine());

Console.Write("Введите максимальное количество элементов в строке: ");
int maxCols = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[rows][];
Random rand = new Random();

for (int i = 0; i < rows; i++)
{
    Console.Write($"Введите количество элементов в строке {i + 1}: ");
    int cols = int.Parse(Console.ReadLine());
    jaggedArray[i] = new int[cols];

    for (int j = 0; j < cols; j++)
    {
        jaggedArray[i][j] = rand.Next(1, 100);
        Console.Write(jaggedArray[i][j] + " ");
    }
    Console.WriteLine();
}

double[] averages = new double[rows];
for (int i = 0; i < rows; i++)
{
    averages[i] = jaggedArray[i].Average();
}

var newJaggedArray = new double[rows + 1][];
for (int i = 0; i < rows; i++)
{
    newJaggedArray[i] = jaggedArray[i].Select(x => (double)x).ToArray();
}
newJaggedArray[rows] = averages;

Console.WriteLine("Новый массив с добавленной строкой средних значений:");
for (int i = 0; i < newJaggedArray.Length; i++)
{
    for (int j = 0; j < newJaggedArray[i].Length; j++)
    {
        Console.Write(newJaggedArray[i][j] + " ");
    }
    Console.WriteLine();
}