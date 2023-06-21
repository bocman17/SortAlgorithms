using SortAlgorithmsLibrary;
int min = -100;
int max = 100;
int[] arr = GenerateRandomArray(10, min, max);
Console.WriteLine("Unsorted");
foreach (var item in arr)
{
    Console.WriteLine(item);
}

int[] expected = new int[arr.Length];
Array.Copy(arr, expected, arr.Length);
Array.Sort(expected);

SortAlgorithms.CombSort(arr);

Console.WriteLine("Expected");
foreach (int i in expected)
{
    Console.WriteLine(i);
}
Console.WriteLine("Sorted");
foreach (int i in arr)
{
    Console.WriteLine(i);
}

int[] GenerateRandomArray(int n, int minValue, int maxValue)
        {
    Random random = new Random();
    int[] array = new int[n];
    for (int i = 0; i < n; i++)
    {
        array[i] = random.Next(minValue, maxValue + 1);
    }
    return array;
}