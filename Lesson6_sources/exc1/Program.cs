Console.WriteLine("Введите цену товара:");
double price = double.Parse(Console.ReadLine() ?? "0");

Console.WriteLine("Выберите тип скидки (1 - Студенческая, 2 - Пенсионерская):");
int choice = int.Parse(Console.ReadLine() ?? "0");

DiscountCalculator discountCalculator = choice switch
{
    1 => new StudentDiscount().CalculateDiscount,
    2 => new SeniorDiscount().CalculateDiscount,
    _ => throw new ArgumentException("Неверный выбор")
};

double discountedPrice = discountCalculator(price);
Console.WriteLine($"Цена со скидкой: {discountedPrice:F2}");

delegate double DiscountCalculator(double price);

class StudentDiscount
{
    public double CalculateDiscount(double price)
    {
        return price * 0.9;
    }
}

class SeniorDiscount
{
    public double CalculateDiscount(double price)
    {
        return price * 0.8;
    }
}