namespace SortAlgorithmsLibrary
{
    public class ConcurrentSorts : SortAlgorithms
    {
        public static void BitonicMergeSort(int[] array)
        {
            BitonicSort(array, 0, array.Length, true);
        }

        private static void BitonicSort(int[] array, int low, int count, bool ascending)
        {
            if (count <= 1)
                return;

            int mid = count / 2;

            BitonicSort(array, low, mid, !ascending);
            BitonicSort(array, low + mid, count - mid, ascending);
            BitonicMerge(array, low, count, ascending);
        }

        private static void BitonicMerge(int[] array, int low, int count, bool ascending)
        {
            if (count <= 1)
                return;

            int k = GreatestPowerOfTwoLessThan(count);

            for (int i = low; i < low + count - k; i++)
            {
                if ((array[i] > array[i + k] && ascending) || (array[i] < array[i + k] && !ascending))
                {
                    Swap(array, i, i + k);
                }
            }

            BitonicMerge(array, low, k, ascending);
            BitonicMerge(array, low + k, count - k, ascending);
        }

        private static int GreatestPowerOfTwoLessThan(int n)
        {
            int k = 1;
            while (k < n)
            {
                k = k << 1;
            }
            return k >> 1;
        }
    }
}
