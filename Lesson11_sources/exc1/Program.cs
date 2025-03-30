Console.WriteLine("Выберите тип пользователя (1 - Админ, 2 - Модератор, 3 - Обычный):");
int choice = int.Parse(Console.ReadLine() ?? "0");

UserFactory factory = choice switch
{
    1 => new AdminFactory(),
    2 => new ModeratorFactory(),
    3 => new RegularFactory(),
    _ => throw new ArgumentException("Неверный выбор")
};

IUser user = factory.CreateUser();
Console.WriteLine($"Права: {user.GetPermissions()}");

interface IUser
{
    string GetPermissions();
}

class AdminUser : IUser
{
    public string GetPermissions() => "Все права";
}

class ModeratorUser : IUser
{
    public string GetPermissions() => "Модерация контента";
}

class RegularUser : IUser
{
    public string GetPermissions() => "Базовые права";
}

abstract class UserFactory
{
    public abstract IUser CreateUser();
}

class AdminFactory : UserFactory
{
    public override IUser CreateUser() => new AdminUser();
}

class ModeratorFactory : UserFactory
{
    public override IUser CreateUser() => new ModeratorUser();
}

class RegularFactory : UserFactory
{
    public override IUser CreateUser() => new RegularUser();
}