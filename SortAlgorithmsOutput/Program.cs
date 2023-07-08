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

int[] arr = GenerateRandomArray(4096, -10000, 10000);
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
ConcurrentSorts.BitonicMergeSort(SampleArr);
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