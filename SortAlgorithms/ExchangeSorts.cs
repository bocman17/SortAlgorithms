namespace SortAlgorithmsLibrary

{
    public class ExchangeSorts : SortAlgorithms
    {
        /// <summary>
        /// Sorts an array of integers using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// Time Complexity: O(n^2) - where n is the number of elements in the array.
        /// Space Complexity: O(1) - Bubble Sort is an in-place sorting algorithm.
        /// </remarks>
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length - 1;
            bool swapped;

            for (int i = 0; i < n; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }

        public static void CoctailShakeSort(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            bool swapped;
            while (left < right)
            {
                swapped = false;
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }

                right--;

                for (int i = right; i > left; i--)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        Swap(arr, i, i - 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }

                left++;
            }
        }

        public static void OddEvenSort(int[] arr)
        {
            bool isSorted = false; // Flag to track if array is sorted
            int n = arr.Length;

            while (!isSorted)
            {
                isSorted = true;

                // Perform odd-even comparisions and swaps
                for (int i = 1; i < n - 1; i += 2)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        isSorted = false;
                    }
                }

                // Perform even-odd comparisions and swaps
                for (int i = 0; i < n - 1; i += 2)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        isSorted = false;
                    }
                }
            }
        }

        public static void CombSort(int[] arr)
        {
            int n = arr.Length;
            int gap = n;
            bool swapped = true;

            while (gap > 1 || swapped)
            {
                gap = GetNextGap(gap);
                swapped = false;

                for (int i = 0; i < n - gap; i++)
                {
                    if (arr[i] > arr[i + gap])
                    {
                        Swap(arr, i, i + gap);
                        swapped = true;
                    }
                }
            }
        }

        private static int GetNextGap(int gap)
        {
            gap = (gap * 10) / 13;
            return Math.Max(1, gap);
        }

        public static void GnomeSort(int[] arr)
        {
            int n = arr.Length;
            int i = 1;
            while (i < n)
            {
                if (arr[i] >= arr[i - 1])
                {
                    i++;
                }
                else
                {
                    Swap(arr, i, i - 1);
                    if (i > 1)
                    {
                        i--;
                    }
                }
            }
        }

        public static void PESort(int[] arr)
        {
            int p = 16; // Adjust the value of p based on your needs

            PESortRecursive(arr, 0, arr.Length - 1, p);
        }

        private static void PESortRecursive(int[] arr, int left, int right, int p)
        {
            if (left < right)
            {
                if (right - left + 1 > p)
                {
                    int median = MedianOfThree(arr, left, right);
                    int[] partitionIndices = Partition(arr, left, right, median);

                    PESortRecursive(arr, left, partitionIndices[0] - 1, p);
                    PESortRecursive(arr, partitionIndices[1] + 1, right, p);
                }
                else
                {
                    InsertionSort(arr, left, right);
                }
            }
        }

        private static int[] Partition(int[] arr, int left, int right, int pivot)
        {
            int i = left;
            int j = right;

            while (true)
            {
                while (arr[i] < pivot)
                    i++;

                while (arr[j] > pivot)
                    j--;

                if (i >= j)
                    break;

                Swap(arr, i, j);

                if (arr[i] == pivot)
                {
                    i++;
                }

                if (arr[j] == pivot)
                {
                    j--;
                }
            }

            return new int[] { i, j };
        }

        private static void InsertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= left && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        private static int MedianOfThree(int[] arr, int left, int right)
        {
            int mid = left + (right - left) / 2;

            if (arr[left] > arr[mid])
                Swap(arr, left, mid);

            if (arr[left] > arr[right])
                Swap(arr, left, right);

            if (arr[mid] > arr[right])
                Swap(arr, mid, right);

            return arr[mid];
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
    }
}
