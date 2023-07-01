using ConsoleTables;
using SortAlgorithmsLibrary;
using SortAlgorithmsOutput;
using System.Diagnostics;

int min = -10000;
int max = 10000;
int[] arr = GenerateRandomArray(100, min, max);
Console.WriteLine("Unsorted");
foreach (var item in arr)
{
    Console.WriteLine(item);
}

int[] expected = new int[arr.Length];
Array.Copy(arr, expected, arr.Length);
Array.Sort(expected);


ExchangeSorts.BubbleSort(arr);

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

List<AlgoInfo> results = new List<AlgoInfo>();

int[] BubbleArr = GenerateRandomArray(4096, min, max);
AlgoInfo BubbleSort = new AlgoInfo("BubbleSort");
Stopwatch BubbleWatch = new Stopwatch();
BubbleWatch.Start();
ExchangeSorts.BubbleSort(BubbleArr);
BubbleWatch.Stop();
BubbleSort.InputArrLen = BubbleArr.Length;
BubbleSort.Ticks = BubbleWatch.ElapsedTicks;
results.Add(BubbleSort);

int[] GnomeArr = GenerateRandomArray(4096, min, max);
AlgoInfo GnomeSort = new AlgoInfo("GnomeSort");
Stopwatch GnomeWatch = new Stopwatch();
GnomeWatch.Start();
ExchangeSorts.GnomeSort(GnomeArr);
GnomeWatch.Stop();
GnomeSort.InputArrLen = GnomeArr.Length;
GnomeSort.Ticks = GnomeWatch.ElapsedTicks;
results.Add(GnomeSort);

int[] CoctailShakeArr = GenerateRandomArray(4096, min, max);
AlgoInfo CoctailShakeSort = new AlgoInfo("CoctailShakeSort");
Stopwatch CoctailShakeWatch = new Stopwatch();
CoctailShakeWatch.Start();
ExchangeSorts.CoctailShakeSort(CoctailShakeArr);
CoctailShakeWatch.Stop();
CoctailShakeSort.InputArrLen = CoctailShakeArr.Length;
CoctailShakeSort.Ticks = CoctailShakeWatch.ElapsedTicks;
results.Add(CoctailShakeSort);

int[] TimArr = GenerateRandomArray(4096, min, max);
AlgoInfo TimSort = new AlgoInfo("TimSort");
Stopwatch TimWatch = new Stopwatch();
TimWatch.Start();
HybridSorts.TimSort(TimArr);
TimWatch.Stop();
TimSort.InputArrLen = TimArr.Length;
TimSort.Ticks = TimWatch.ElapsedTicks;
results.Add(TimSort);

var sortedResults = results.OrderBy(x => x.InputArrLen).ThenBy(x => x.Ticks).ToList();

var table = new ConsoleTable("Algorithm", "Input Length", "Ticks");
for (int i = 0; i < sortedResults.Count; i++)
{
    table.AddRow(sortedResults[i].Title, sortedResults[i].InputArrLen, sortedResults[i].Ticks);
}

table.Write();
Console.WriteLine();