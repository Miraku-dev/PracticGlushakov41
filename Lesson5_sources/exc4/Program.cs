Console.WriteLine("Выберите тип подключения (1 - SQL, 2 - NoSQL):");
int choice = int.Parse(Console.ReadLine() ?? "0");

DatabaseConnector connector = new DatabaseConnector();

if (choice == 1)
{
    ISqlDatabase sqlConnector = connector;
    sqlConnector.Connect();
}
else if (choice == 2)
{
    INoSqlDatabase noSqlConnector = connector;
    noSqlConnector.Connect();
}
else
{
    Console.WriteLine("Неверный выбор.");
}

interface ISqlDatabase
{
    void Connect();
}

interface INoSqlDatabase
{
    void Connect();
}

class DatabaseConnector : ISqlDatabase, INoSqlDatabase
{
    void ISqlDatabase.Connect()
    {
        Console.WriteLine("Подключение к SQL базе данных.");
    }

    void INoSqlDatabase.Connect()
    {
        Console.WriteLine("Подключение к NoSQL базе данных.");
    }
}