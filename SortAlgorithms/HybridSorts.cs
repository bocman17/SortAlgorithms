namespace SortAlgorithmsLibrary
{
    public class HybridSorts : SortAlgorithms
    {
        /// <summary>
        /// Sorts an array of integers in ascending order using the TimSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// TimSort is a hybrid sorting algorithm derived from Merge Sort and Insertion Sort. It works by dividing the
        /// array into small runs and sorting them using Insertion Sort. The sorted runs are then merged using a modified
        /// Merge Sort algorithm. TimSort is highly efficient for sorting real-world data that often has some degree of
        /// pre-sortedness or patterns.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O(n log n) - where n is the number of elements in the array. TimSort has a time complexity
        /// of O(n log n) on average and in the worst-case scenarios. It performs well on both small and large arrays and is
        /// particularly efficient for partially sorted or nearly sorted arrays.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(n) - TimSort requires additional space for merging the runs and temporary arrays.
        /// The space complexity is determined by the size of the input array.
        /// </para>
        /// </remarks>
        public static void TimSort(int[] arr)
        {
            int n = arr.Length;
            int minRun = GetMinRun(n);

            // Perform insertion sort on small runs
            for (int i = 0; i < n; i += minRun)
            {
                // Determine the boundaries of the current run
                int left = i;
                int right = Math.Min(i + minRun - 1, n - 1);

                // Sort the current run using insertion sort
                InsertionSort(arr, left, right);
            }

            int size = minRun;
            while (size < n)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min(left + 2 * size - 1, n - 1);

                    // Merge adjacent runs
                    Merge(arr, left, mid, right);
                }

                size *= 2;
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int len1 = mid - left + 1;
            int len2 = right - mid;

            int[] leftArr = new int[len1];
            int[] rightArr = new int[len2];

            // Copy the elements into temporary arrays
            Array.Copy(arr, left, leftArr, 0, len1);
            Array.Copy(arr, mid + 1, rightArr, 0, len2);

            int i = 0;
            int j = 0;
            int k = left;

            // Merge the temporary arrays back into the original array
            while (i < len1 && j < len2)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            // Copy the remaining elements of leftArr, if any remains
            while (i < len1)
            {
                arr[k] = leftArr[i];
                i++;
                k++;
            }

            // Copy the remaining elements of rightArr, if any remains
            while (j < len2)
            {
                arr[k] = rightArr[j];
                j++;
                k++;
            }
        }

        private static void InsertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = arr[i];
                int j = i - 1;

                // Insert the current element into the sorted sequence
                while (j >= left && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        private static int GetMinRun(int n)
        {
            int r = 0;
            while (n >= 64)
            {
                r |= n & 1;
                n >>= 1;
            }

            return n + r;
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the IntroSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// IntroSort is a hybrid sorting algorithm that combines the quicksort, heapsort, and insertion sort algorithms.
        /// It starts with quicksort and switches to heapsort when the recursion depth exceeds a specified limit. If the
        /// input size becomes small, it switches to insertion sort for efficiency. IntroSort provides a good balance
        /// between the average-case and worst-case time complexities of the sorting algorithms it combines.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log n) - IntroSort has an average-case time complexity of O(n log n) for most inputs.
        /// - Worst Case: O(n log n) - In the worst-case scenario, the time complexity is O(n log n), similar to quicksort.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(log n) - The space complexity of IntroSort is determined by the stack space used
        /// for recursion, which is proportional to the logarithm of the input size.
        /// </para>
        /// </remarks>
        public static void IntroSort(int[] arr)
        {
            int maxDepth = (int)Math.Floor(Math.Log(arr.Length, 2)) * 2;
            IntroSortRecursive(arr, 0, arr.Length - 1, maxDepth);
        }

        private static void IntroSortRecursive(int[] arr, int left, int right, int depthLimit)
        {
            if (left < right)
            {
                if (depthLimit == 0)
                {
                    // If the depth limit is reached, switch to Heapsort
                    HeapSort(arr, left, right);
                }
                else
                {
                    // Perform Quicksort partitioning
                    int partitionIndex = Partition(arr, left, right);

                    // Recursively sort the left and right partitions   
                    IntroSortRecursive(arr, left, partitionIndex, depthLimit - 1);
                    IntroSortRecursive(arr, partitionIndex + 1, right, depthLimit - 1);
                }
            }
        }

        private static void HeapSort(int[] arr, int left, int right)
        {
            int n = right - left + 1;

            // Build the heap in the array
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i, left);
            }

            // Extract elements from the heap one by one
            for (int i = n - 1; i >= 0; i--)
            {
                // Move the current root (maximum value) to the end of the array
                Swap(arr, left, left + i);

                // Heapify the reduced heap
                Heapify(arr, i, 0, left);
            }
        }

        private static void Heapify(int[] arr, int n, int i, int offset)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // Find the largest element among the root, left child, and right child
            if (left < n && arr[offset + left] > arr[offset + largest])
            {
                largest = left;
            }

            if (right < n && arr[offset + right] > arr[offset + largest])
            {
                largest = right;
            }

            // If the largest element is not the root, swap them and continue heapifying
            if (largest != i)
            {
                Swap(arr, offset + i, offset + largest);
                Heapify(arr, n, largest, offset);
            }
        }
    }
}
