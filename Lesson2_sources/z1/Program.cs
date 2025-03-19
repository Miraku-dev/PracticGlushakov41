int[] array = { 12, 45, 6, 23, 9, 3, 17 };
int minValue = array.Min();
int minIndex = Array.IndexOf(array, minValue);

Console.WriteLine($"Минимальный элемент: {minValue}");
Console.WriteLine($"Порядковый номер: {minIndex}");