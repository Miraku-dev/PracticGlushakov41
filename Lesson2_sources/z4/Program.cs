int rows = 23;
int seats = 40;
int[,] tickets = new int[rows, seats];

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < seats; j++)
    {
        Console.Write($"Введите статус места {j + 1} в ряду {i + 1} (1 - продано, 0 - свободно): ");
        tickets[i, j] = int.Parse(Console.ReadLine());
    }
}

bool hasFreeSeats = false;
for (int j = 0; j < seats; j++)
{
    if (tickets[0, j] == 0)
    {
        hasFreeSeats = true;
        break;
    }
}

Console.WriteLine(hasFreeSeats ? "В первом ряду есть свободные места." : "В первом ряду нет свободных мест.");