Console.WriteLine("Введите ID заказа:");
int orderId = int.Parse(Console.ReadLine() ?? "0");

Console.WriteLine("Выберите действие (1 - Одобрить, 2 - Отменить):");
int choice = int.Parse(Console.ReadLine() ?? "0");

OrderProcessor orderProcessor = choice switch
{
    1 => ApproveOrder,
    2 => CancelOrder,
    _ => throw new ArgumentException("Неверный выбор")
};

ProcessOrder(orderId, orderProcessor);

static void ProcessOrder(int orderId, OrderProcessor processor)
{
    processor(orderId);
}

static void ApproveOrder(int orderId)
{
    Console.WriteLine($"Заказ {orderId} одобрен.");
}

static void CancelOrder(int orderId)
{
    Console.WriteLine($"Заказ {orderId} отменен.");
}

delegate void OrderProcessor(int orderId);