namespace SortAlgorithmsLibrary
{
    public partial class SortAlgorithms
    {
        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return;
            }

            int middle = arr.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[arr.Length - middle];

            Array.Copy(arr, 0, left, 0, middle);
            Array.Copy(arr, middle, right, 0, arr.Length - middle);

            MergeSort(left);
            MergeSort(right);

            Merge(arr, left, right);
        }

        private static void Merge(int[] mergedArr, int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    mergedArr[mergedIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergedArr[mergedIndex] = right[rightIndex];
                    rightIndex++;
                }

                mergedIndex++;
            }

            while (leftIndex < left.Length)
            {
                mergedArr[mergedIndex] = left[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            while (rightIndex < right.Length)
            {
                mergedArr[mergedIndex] = right[rightIndex];
                rightIndex++;
                mergedIndex++;
            }
        }

        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                QuickSort(arr, left, pivot - 1);
                QuickSort(arr, pivot + 1, right);
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;

                    // Swap elements if they are less than or equal to the pivot
                    Swap(arr, i, j);
                }
            }
            // Move the pivot to its correct position
            Swap(arr, i + 1, right);

            return i + 1;
        }

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
