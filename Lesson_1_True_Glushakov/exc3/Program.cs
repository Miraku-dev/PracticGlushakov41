Console.Write("Введите цену за 1 кг конфет: ");
double price = double.Parse(Console.ReadLine());

for (double weight = 0.1; weight <= 1.0; weight += 0.1)
{
    Console.WriteLine($"{weight:F1} кг: {price * weight:F2} руб.");
}