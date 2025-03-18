Console.Write("Введите стоимость одной штуки товара: ");
double price = double.Parse(Console.ReadLine());

Console.WriteLine("Способ 1: while");
int count = 10;
while (count <= 200)
{
    Console.WriteLine($"{count} шт.: {price * count}");
    count += 10;
}

Console.WriteLine("Способ 2: do while");
count = 10;
do
{
    Console.WriteLine($"{count} шт.: {price * count}");
    count += 10;
} while (count <= 200);

Console.WriteLine("Способ 3: for");
for (int i = 10; i <= 200; i += 10)
{
    Console.WriteLine($"{i} шт.: {price * i}");
}