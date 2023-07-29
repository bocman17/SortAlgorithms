using SortAlgorithms.HelperClasses;

namespace SortAlgorithmsLibrary
{
    public class HybridSorts : SortAlgorithms
    {
        #region TimSort
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
        #endregion

        #region IntroSort
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
        #endregion

        #region BlockSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the BlockSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// BlockSort is an integer sorting algorithm that divides the input array into blocks of a fixed size (blockSize), sorts each block
        /// individually, and then merges the sorted blocks into a single sorted list. BlockSort is particularly useful for sorting large arrays
        /// or datasets where the elements have a limited range, and it can achieve better performance compared to some traditional sorting
        /// algorithms like quicksort or mergesort.
        /// </para>
        /// <para>
        /// The algorithm starts by dividing the input array into blocks of size blockSize (rounded down to the nearest integer). Each block is then
        /// sorted using a simple sorting algorithm, such as insertion sort or selection sort. The sorted blocks are stored in a list called "blocks."
        /// </para>
        /// <para>
        /// The algorithm proceeds with the merging step, where it repeatedly finds the smallest element in the first block of each sorted block
        /// and adds it to the original array. The smallest element is then removed from its block, and if the block becomes empty, it is removed
        /// from the list of blocks. The merging process continues until all blocks have been emptied and merged into the original array, resulting
        /// in a fully sorted array.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n * sqrt(n)), where n is the size of the input array. BlockSort divides the array into blocks of size sqrt(n), and
        ///   each block is sorted individually with a time complexity of O(sqrt(n) * log(sqrt(n))) using a simple sorting algorithm. The merging
        ///   process requires comparing and merging each element, resulting in a total time complexity of O(n * sqrt(n)).
        /// - Worst Case: O(n * sqrt(n)), the worst-case time complexity occurs when all elements fall into the same block, resulting in the same
        ///   time complexity as the average case.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b>
        /// - Average Case: O(n * sqrt(n)), the space complexity of BlockSort is determined by the size of the input array (n) and the number of
        ///   blocks (sqrt(n)). The algorithm requires additional space to create and store the blocks while sorting the input array.
        /// - Worst Case: O(n * sqrt(n)), the worst-case space complexity of BlockSort also occurs when all elements fall into the same block,
        ///   resulting in the same space complexity as the average case.
        /// </para>
        /// </remarks>
        public static void BlockSort(int[] arr)
        {
            int n = arr.Length;
            if (n <= 1)
            {
                return;
            }
            int blockSize = (int)Math.Sqrt(n);

            List<List<int>> blocks = new List<List<int>>();

            // Divide the input array into blocks of size blockSize
            for (int i = 0; i < n; i += blockSize)
            {
                List<int> block = new List<int>();

                for (int j = i; j < i + blockSize && j < n; j++)
                {
                    block.Add(arr[j]);
                }

                // Sort each block and append it to the list of sorted blocks
                block.Sort();
                blocks.Add(block);
            }

            // Merge the sorted blocks into a single sorted list
            int index = 0;
            while (blocks.Any())
            {
                // Find the smallest element in the first block of each sorted block
                int minIndex = 0;

                for (int i = 1; i < blocks.Count; i++)
                {
                    if (blocks[i][0] < blocks[minIndex][0])
                    {
                        minIndex = i;
                    }
                }

                // Remove the smallest element and put it in the original array
                arr[index++] = blocks[minIndex][0];
                blocks[minIndex].RemoveAt(0);

                if (!blocks[minIndex].Any())
                {
                    blocks.RemoveAt(minIndex);
                }
            }
        }
        #endregion

        #region KirkpatrickReischSort
        // TODO
        #endregion

        #region SpreadSort
        // TODO
        #endregion

        #region MergeInsertionSort

        /// <summary>
        /// Sorts the input array using the Merge-Insertion Sort algorithm.
        /// The algorithm combines Merge Sort and Insertion Sort for improved performance.
        /// For small subarrays (size <= threshold), it uses Insertion Sort, and for larger subarrays, it uses Merge Sort.
        /// </summary>
        /// <param name="arr">The input array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// <b>Merge-Insertion Sort</b> is a hybrid sorting algorithm that aims to take advantage of both Merge Sort and Insertion Sort.
        /// It is an optimization over regular Merge Sort to improve the overall performance on smaller subarrays.
        /// </para>
        /// <para>
        /// The algorithm recursively divides the input array into subarrays and uses Insertion Sort for subarrays of size less than or equal to a given threshold.
        /// For larger subarrays, it applies the traditional Merge Sort by recursively dividing the array into halves until the subarrays have a size less than or equal to the threshold.
        /// </para>
        /// <para>
        /// The threshold value is automatically adjusted based on the input array size, and it is set to a default value of 16 if the logarithm of the array size (base 2) is greater than 4.
        /// The idea is to utilize the efficiency of Insertion Sort for small subarrays (low overhead) and switch to Merge Sort for larger subarrays (better for larger data sets).
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> The average and worst-case time complexity of Merge-Insertion Sort is O(n log n).
        /// However, the use of Insertion Sort for small subarrays improves the algorithm's performance on partially sorted or nearly sorted data.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> Merge-Insertion Sort has a space complexity of O(n) due to the use of temporary arrays in the Merge step.
        /// </para>
        /// <para>
        /// Note: Merge-Insertion Sort is efficient for general-purpose sorting when the constant overhead of Merge Sort is high relative to Insertion Sort.
        /// The choice of the threshold value can have an impact on the algorithm's performance for specific data sets.
        /// </para>
        /// </remarks>
        public static void MergeInsertionSort(int[] arr)
        {
            int n = arr.Length;
            if(n <= 1)
            {
                // If the array has 0 or 1 element, it is already sorted, so return early
                return;
            }
            int threshold = 16; // Default threshold value for switching to Insertion Sort
            int logN = (int)Math.Log(n, 2);

            // Adjust the threshold based on the input array length to optimize performance
            if (logN > 4)
            {
                threshold = (int)Math.Pow(2, logN - 4);
            }

            // Call the recursive MergeInsertionSort function with the given threshold
            MergeInsertionSortRecursive(arr, 0, arr.Length - 1, threshold);
        }

        // Merge two sorted subarrays: arr[left..mid] and arr[mid+1..right]
        private static void MergeMIS(int[] arr, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = mid + 1, k = 0;

            // Merge the two subarrays into the temporary array 'temp'
            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                    temp[k++] = arr[i++];
                else
                    temp[k++] = arr[j++];
            }

            // Copy any remaining elements from the first subarray (if any)
            while (i <= mid)
                temp[k++] = arr[i++];

            // Copy any remaining elements from the second subarray (if any)
            while (j <= right)
                temp[k++] = arr[j++];

            // Copy the sorted elements from the temporary array 'temp' back to the original array 'arr'
            Array.Copy(temp, 0, arr, left, temp.Length);
        }

        // Insertion Sort implementation for sorting small subarrays
        private static void InsertionSortMIS(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = arr[i];
                int j = i - 1;

                // Shift elements to the right to make space for the current key
                while (j >= left && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                // Insert the key at its correct position
                arr[j + 1] = key;
            }
        }

        // Recursive implementation of Merge-Insertion Sort
        private static void MergeInsertionSortRecursive(int[] arr, int left, int right, int threshold)
        {
            // Base case: if the subarray has 1 or fewer elements, it is already sorted, so return early
            if (left >= right)
                return;

            // If the size of the subarray is below the threshold, switch to Insertion Sort
            if (right - left + 1 <= threshold)
            {
                InsertionSortMIS(arr, left, right);
            }
            else
            {
                // Divide the array into two halves and sort each half recursively
                int mid = (left + right) / 2;
                MergeInsertionSortRecursive(arr, left, mid, threshold);
                MergeInsertionSortRecursive(arr, mid + 1, right, threshold);
                // Merge the two sorted halves
                MergeMIS(arr, left, mid, right);
            }
        }

        #endregion
    }
}
