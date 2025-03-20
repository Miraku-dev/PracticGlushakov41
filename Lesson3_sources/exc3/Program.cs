var products = new Product[]
{
    new Electronics { Name = "Ноутбук", Price = 1200, Quantity = 10 },
    new Clothing { Name = "Куртка", Price = 100, Quantity = 50 },
    new Electronics { Name = "Смартфон", Price = 800, Quantity = 30 }
};

var warehouse = new Warehouse(products);

Console.WriteLine($"Общая стоимость товаров на складе: {warehouse.GetTotalStockValue()}");
var mostExpensive = warehouse.FindMostExpensiveProduct();
Console.WriteLine($"Самый дорогой товар: {mostExpensive.Name} - {mostExpensive.Price}");

abstract class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

sealed class Electronics : Product { }

sealed class Clothing : Product { }

class Warehouse
{
    private Product[] products;

    public Warehouse(Product[] products)
    {
        this.products = products;
    }

    public decimal GetTotalStockValue()
    {
        return products.Sum(p => p.Price * p.Quantity);
    }

    public Product FindMostExpensiveProduct()
    {
        return products.OrderByDescending(p => p.Price).FirstOrDefault();
    }
}