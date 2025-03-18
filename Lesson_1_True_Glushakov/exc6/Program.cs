Console.Write("Введите пол (м - мужчина, ж - женщина): ");
char gender = char.Parse(Console.ReadLine());

switch (gender)
{
    case 'м':
        Console.WriteLine("Возможные мужские имена: Александр, Дмитрий, Иван, Михаил, Сергей");
        break;
    case 'ж':
        Console.WriteLine("Возможные женские имена: Анна, Елена, Мария, Ольга, Татьяна");
        break;
    default:
        Console.WriteLine("Неверный ввод. Введите 'м' или 'ж'.");
        break;
}