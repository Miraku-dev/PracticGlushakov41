Console.WriteLine("Введите элементы через пробел:");
var items = Console.ReadLine()?.Split() ?? Array.Empty<string>();

var manager = new LinkedListManager<string>();
foreach (var item in items) manager.AddLast(item);

Console.WriteLine($"Список: {string.Join(", ", manager.GetAllItems())}");

Console.WriteLine("Удалить элемент:");
manager.Remove(Console.ReadLine() ?? "");

Console.WriteLine($"Обновленный список: {string.Join(", ", manager.GetAllItems())}");

class Node<T>(T value)
{
    public T Value = value;
    public Node<T>? Next;
    public Node<T>? Previous;
}

class MyLinkedList<T>
{
    private Node<T>? _head, _tail;

    public void AddLast(T item)
    {
        var newNode = new Node<T>(item);
        if (_tail == null) _head = _tail = newNode;
        else
        {
            newNode.Previous = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
    }

    public bool Remove(T item)
    {
        for (var current = _head; current != null; current = current.Next)
        {
            if (!EqualityComparer<T>.Default.Equals(current.Value, item)) continue;

            if (current.Previous != null) current.Previous.Next = current.Next;
            else _head = current.Next;

            if (current.Next != null) current.Next.Previous = current.Previous;
            else _tail = current.Previous;

            return true;
        }
        return false;
    }

    public IEnumerable<T> GetAllItems()
    {
        for (var current = _head; current != null; current = current.Next)
            yield return current.Value;
    }
}

class LinkedListManager<T>
{
    private readonly MyLinkedList<T> _list = new();

    public void AddLast(T item) => _list.AddLast(item);
    public bool Remove(T item) => _list.Remove(item);
    public IEnumerable<T> GetAllItems() => _list.GetAllItems();
}