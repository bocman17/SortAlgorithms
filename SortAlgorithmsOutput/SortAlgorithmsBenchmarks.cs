using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using SortAlgorithmsLibrary;

namespace SortAlgorithmsOutput
{

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SortAlgorithmsBenchmarks
    {
        private static int[] GenerateRandomArray(int n, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }
            return array;
        }

        public static int[] arr = GenerateRandomArray(4096, -100000, 100000);
        int[] bubbleArr = (int[])arr.Clone();
        int[] quickArr = (int[])arr.Clone();


        [Benchmark]
        public void QuickBenchmark()
        {
            ExchangeSorts.QuickSort(quickArr);
        }

        [Benchmark]
        public void BubbleSortBenchmark()
        {
            ExchangeSorts.BubbleSort(bubbleArr);
        }

        int[] coctailShakerArr = (int[])arr.Clone();
        int[] oddEvenArr = (int[])arr.Clone();
        int[] combArr = (int[])arr.Clone();
        int[] gnomeArr = (int[])arr.Clone();
        int[] peArr = (int[])arr.Clone();
        //[Benchmark]
        //public void CoctailShakerBenchmark()
        //{
        //    ExchangeSorts.CoctailShakerSort(coctailShakerArr);
        //}

        //[Benchmark]
        //public void OddEvenBenchmark()
        //{
        //    ExchangeSorts.OddEvenSort(oddEvenArr);
        //}

        //[Benchmark]
        //public void CombBenchmark()
        //{
        //    ExchangeSorts.CombSort(combArr);
        //}

        //[Benchmark]
        //public void GnomeBenchmark()
        //{
        //    ExchangeSorts.GnomeSort(gnomeArr);
        //}

        //[Benchmark]
        //public void PEBenchmark()
        //{
        //    ExchangeSorts.PESort(peArr);
        //}
    }
}
