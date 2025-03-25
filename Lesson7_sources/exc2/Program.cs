Console.WriteLine("Введите URL для отправки запроса:");
string url = Console.ReadLine() ?? string.Empty;

try
{
    RequestHandler handler = new RequestHandler();
    var response = await handler.ProcessRequestAsync(url);
    Console.WriteLine($"Запрос успешен. Код статуса: {response.StatusCode}");
}
catch (ApiException ex)
{
    Console.WriteLine($"Ошибка API: {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.WriteLine($"Техническая информация: {ex.InnerException.Message}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
}

class ApiException : Exception
{
    public ApiException() : base("Ошибка API") { }
    public ApiException(string message) : base(message) { }
    public ApiException(string message, Exception inner) : base(message, inner) { }
}

class ApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();

    public async Task<HttpResponseMessage> SendRequestAsync(string url)
    {
        try
        {
            return await _httpClient.GetAsync(url);
        }
        catch (HttpRequestException ex)
        {
            throw new ApiException($"Ошибка при запросе к {url}", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new ApiException("Таймаут запроса", ex);
        }
    }
}

class RequestHandler
{
    private readonly ApiClient _client = new ApiClient();

    public async Task<HttpResponseMessage> ProcessRequestAsync(string url)
    {
        try
        {
            return await _client.SendRequestAsync(url);
        }
        catch (ApiException ex)
        {
            Console.WriteLine("Произошла ошибка API");
            throw;
        }
    }
}