using SortAlgorithmsLibrary;
using System.Diagnostics;

static int[] GenerateRandomArray(int n, int minValue, int maxValue)
{
    Random random = new Random();
    int[] array = new int[n];
    for (int i = 0; i < n; i++)
    {
        array[i] = random.Next(minValue, maxValue + 1);
    }
    return array;
}

static string[] GenerateRandomStringArray(int n, int minLength, int maxLength)
{
    string[] array = new string[n];
    Random random = new Random();

    for (int i = 0; i < n; i++)
    {
        int stringLength = random.Next(minLength, maxLength);
        array[i] = GenerateRandomString(stringLength);
    }

    return array;
}

static string GenerateRandomString(int stringLength)
{
    char[] result = new char[stringLength];
    Random random = new Random();
    string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

    for (int i = 0; i < stringLength; i++)
    {
        result[i] = Chars[random.Next(Chars.Length)];
    }
    return new string(result);
}

int[] arr = GenerateRandomArray(4096, 0, 10);
int[] bubbleArr = (int[])arr.Clone();
int[] quickArr = (int[])arr.Clone();
int[] SampleArr = (int[])arr.Clone();

Console.WriteLine("before");
foreach (int num in arr)
{
    Console.WriteLine(num);
}
Console.WriteLine("expected");
Array.Sort(arr);
foreach (int num in arr)
{
    Console.WriteLine(num);
}
Console.WriteLine("sorted");
MergeSorts.PolyphaseMergeSort(SampleArr);
foreach (int num in SampleArr)
{
    Console.WriteLine(num);
}

Stopwatch bubbleWatch = new Stopwatch();
Stopwatch quickWatch = new Stopwatch();

bubbleWatch.Start();
ExchangeSorts.BubbleSort(bubbleArr);
bubbleWatch.Stop();
Console.WriteLine(bubbleWatch.Elapsed);

quickWatch.Start();
ExchangeSorts.QuickSort(quickArr);
quickWatch.Stop();
Console.WriteLine(quickWatch.Elapsed);
