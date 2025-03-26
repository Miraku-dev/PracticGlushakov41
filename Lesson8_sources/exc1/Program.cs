Console.WriteLine("Введите количество заявок:");
int count = int.Parse(Console.ReadLine() ?? "0");

ServiceRequestManager manager = new ServiceRequestManager();

for (int i = 0; i < count; i++)
{
    Console.WriteLine($"Заявка {i + 1}:");
    Console.WriteLine("Введите имя клиента:");
    string name = Console.ReadLine() ?? "Клиент";

    Console.WriteLine("Введите тип заявки:");
    string type = Console.ReadLine() ?? "Тип";

    manager.AddRequest(new ServiceRequest(i + 1, name, type));
}

Console.WriteLine("Обработка заявок:");
while (manager.HasRequests)
{
    var request = manager.ProcessNextRequest();
    Console.WriteLine($"Обработана заявка #{request.Id} от {request.CustomerName} ({request.RequestType})");
}

class ServiceRequest
{
    public int Id { get; }
    public string CustomerName { get; }
    public string RequestType { get; }

    public ServiceRequest(int id, string customerName, string requestType)
    {
        Id = id;
        CustomerName = customerName;
        RequestType = requestType;
    }
}

class ServiceRequestManager
{
    private readonly Queue<ServiceRequest> _requests = new Queue<ServiceRequest>();

    public bool HasRequests => _requests.Count > 0;

    public void AddRequest(ServiceRequest request)
    {
        _requests.Enqueue(request);
    }

    public ServiceRequest ProcessNextRequest()
    {
        return _requests.Dequeue();
    }

    public ServiceRequest PeekNextRequest()
    {
        return _requests.Peek();
    }
}