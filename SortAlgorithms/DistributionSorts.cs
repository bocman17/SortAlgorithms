namespace SortAlgorithmsLibrary
{
    public class DistributionSorts : SortAlgorithms
    {
        public static void RadixSort(int[] arr)
        {
            if (arr is null || arr.Length < 2)
            {
                return;
            }

            int max = GetMaxValue(arr);

            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(arr, exp);
            }
        }

        private static void CountingSort(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n];
            int[] count = new int[19]; // Counting array for -9 to 9 (including 0)

            for (int i = 0; i < 19; i++)
            {
                count[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                count[GetDigit(arr[i], exp)]++;
            }

            for (int i = 1; i < 19; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[GetDigit(arr[i], exp)] - 1] = arr[i];
                count[GetDigit(arr[i], exp)]--;
            }

            Array.Copy(output, arr, n);
        }

        private static int GetDigit(int num, int exp)
        {
            return (num / exp) % 10 + 9;
        }

        private static int GetMaxValue(int[] arr)
        {
            int max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
    }
}
