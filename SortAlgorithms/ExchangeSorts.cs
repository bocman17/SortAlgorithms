namespace SortAlgorithmsLibrary

{
    public class ExchangeSorts : SortAlgorithms
    {
        #region BubbleSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Bubble Sort is a simple comparison-based sorting algorithm.
        /// It repeatedly swaps adjacent elements if they are in the wrong order,
        /// gradually moving the larger elements towards the end of the array.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O(n^2) - where n is the number of elements in the array.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - Bubble Sort operates in-place, requiring only a constant amount of extra space.
        /// </para>
        /// </remarks>
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length - 1;
            bool swapped;

            for (int i = 0; i < n; i++) // Start the Bubble Sort algorithm
            {
                swapped = false;
                for (int j = 0; j < n - i; j++) // Perform a pass through the array
                {
                    if (arr[j] > arr[j + 1]) // Compare adjacent elements and swap them if they are out of order
                    {
                        Swap(arr, j, j + 1);
                        swapped = true;
                    }
                }
                if (!swapped) // If no swaps occurred during the pass, the array is already sorted, so we break the loop
                {
                    break;
                }
            }
        }
        #endregion

        #region CoctailShakerSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the Cocktail Shaker Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Cocktail Shaker Sort, also known as Bidirectional Bubble Sort or Cocktail Sort,
        /// is a variation of the Bubble Sort algorithm. It sorts the array in both directions,
        /// moving the largest elements to the end in the first pass, and the smallest elements to the beginning in the second pass.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O(n^2) - where n is the number of elements in the array.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - Cocktail Shaker Sort operates in-place, requiring only a constant amount of extra space.
        /// </para>
        /// </remarks>
        public static void CoctailShakerSort(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            bool swapped;
            while (left < right) // Start the Cocktail Shaker Sort algorithm
            {
                swapped = false;
                for (int i = left; i < right; i++) // Perform a forward pass from left to right
                {
                    if (arr[i] > arr[i + 1]) // Compare adjacent elements and swap them if they are out of order
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                    }
                }
                if (!swapped) // If no swaps occurred during the forward pass, the array is already sorted, so we break the loop
                {
                    break;
                }

                right--; // Move the right boundary one position to the left

                for (int i = right; i > left; i--) // Perform a backward pass from right to left
                {
                    if (arr[i] < arr[i - 1]) // Compare adjacent elements and swap them if they are out of order
                    {
                        Swap(arr, i, i - 1);
                        swapped = true;
                    }
                }
                if (!swapped) // If no swaps occurred during the backward pass, the array is already sorted, so we break the loop
                {
                    break;
                }
                left++; // Move the left boundary one position to the right
            }
        }
        #endregion

        #region OddEvenSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the Odd-Even Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Odd-Even Sort, also known as Brick Sort or Exchange Sort, is a parallel variation of the Bubble Sort algorithm.
        /// It compares and swaps adjacent elements in alternating odd-even passes until the array is sorted.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O(n^2) - where n is the number of elements in the array.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - Odd-Even Sort operates in-place, requiring only a constant amount of extra space.
        /// </para>
        /// </remarks>
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
        #endregion

        #region CombSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the Comb Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Comb Sort is a variation of Bubble Sort that introduces a gap size for comparing and swapping elements.
        /// It repeatedly shrinks the gap until it becomes 1, at which point it performs a final pass using Bubble Sort.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O(n^2) - where n is the number of elements in the array.
        /// In the best case scenario (already sorted or nearly sorted), it has a time complexity of O(n*log(n)).
        /// </para>
        /// <para>
        /// <b>Space Complexity</b>: O(1) - Comb Sort operates in-place, requiring only a constant amount of extra space.
        /// </para>
        /// </remarks>
        public static void CombSort(int[] arr)
        {
            int n = arr.Length;
            int gap = n;
            bool swapped = true;

            while (gap > 1 || swapped) // Start the Comb Sort algorithm
            {
                gap = GetNextGap(gap); // Calculate the next gap using the GetNextGap method
                swapped = false;

                for (int i = 0; i < n - gap; i++) // Iterate over the array with the calculated gap
                {
                    if (arr[i] > arr[i + gap]) // Compare elements with a distance of 'gap' and swap them if they are out of order
                    {
                        Swap(arr, i, i + gap);
                        swapped = true;
                    }
                }
            }
        }

        private static int GetNextGap(int gap)
        {
            gap = (gap * 10) / 13; // Calculate the next gap using a shrink factor of 1.3 (10/13)
            return Math.Max(1, gap); // Ensure the gap is at least 1
        }
        #endregion

        #region GnomeSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the Gnome Sort algorithm, also known as Stupid Sort.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Gnome Sort is a simple comparison-based sorting algorithm that works by repeatedly
        /// swapping adjacent elements if they are in the wrong order, similar to the technique used in Bubble Sort.
        /// However, Gnome Sort also includes a backward movement to recheck the previous element after a swap.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O(n^2) - where n is the number of elements in the array.
        /// In the best case scenario (already sorted or nearly sorted), it has a time complexity of O(n).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - Gnome Sort operates in-place, requiring only a constant amount of extra space.
        /// </para>
        /// </remarks>
        public static void GnomeSort(int[] arr)
        {
            int n = arr.Length;
            int i = 1;
            // Start the Gnome Sort algorithm
            while (i < n)
            {
                // Check if the current element is greater than or equal to the previous element
                if (arr[i] >= arr[i - 1])
                {
                    i++; // If true, move to the next element
                }
                else
                {
                    Swap(arr, i, i - 1); // If false, swap the current element with the previous element
                    if (i > 1) // Move one step back (if possible) to compare the swapped element with its previous element
                    {
                        i--;
                    }
                }
            }
        }
        #endregion

        #region PESort
        /// <summary>
        /// Sorts an array of integers in ascending order using the PESort (Proportion Extend Sort) algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// PESort (Proportion Extend Sort) is a hybrid sorting algorithm that combines the concepts of quicksort and
        /// insertion sort. It uses a recursive approach where the array is divided into subarrays and sorted using either
        /// quicksort or insertion sort, depending on the size of the subarray.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O(n log n) - where n is the number of elements in the array. The time complexity of PESort
        /// can vary depending on the chosen pivot value, but it typically performs well on average and in most cases.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(log n) - PESort operates recursively, consuming additional space on the call stack
        /// for each recursive call. The space complexity is determined by the maximum depth of the recursive calls, which is
        /// log n for an array of size n.
        /// </para>
        /// </remarks>
        public static void PESort(int[] arr)
        {
            int p = 16; // Adjust the value of p based on your needs

            // Call the private PESortRecursive method with initial left and right indices and p value
            PESortRecursive(arr, 0, arr.Length - 1, p);
        }

        private static void PESortRecursive(int[] arr, int left, int right, int p)
        {
            if (left < right)
            {
                if (right - left + 1 > p)
                {
                    // Choose the pivot using the Median of Three method
                    int median = MedianOfThree(arr, left, right); 
                    int[] partitionIndices = Partition(arr, left, right, median); // Partition the array around the pivot

                    PESortRecursive(arr, left, partitionIndices[0] - 1, p); // Recursively sort the left partition
                    PESortRecursive(arr, partitionIndices[1] + 1, right, p); // Recursively sort the right partition
                }
                else
                {
                    InsertionSort(arr, left, right); // Use Insertion Sort for small partitions
                }
            }
        }
        private static int[] Partition(int[] arr, int left, int right, int pivot)
        {
            int i = left;
            int j = right;

            while (true)
            {
                while (arr[i] < pivot) // Find the element on the left side greater than the pivot
                    i++;

                while (arr[j] > pivot) // Find the element on the right side smaller than the pivot
                    j--;

                if (i >= j)
                    break;

                Swap(arr, i, j); // Swap the elements found above

                if (arr[i] == pivot) // Move past duplicate elements equal to the pivot
                {
                    i++;
                }

                if (arr[j] == pivot) // Move past duplicate elements equal to the pivot
                {
                    j--;
                }
            }

            return new int[] { i, j }; // Return the indices of the partitioned subarray
        }

        private static void InsertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++) // Perform Insertion Sort within the given range
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= left && arr[j] > key)  // Shift elements greater than key to the right
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key; // Insert the key in its correct position
            }
        }

        private static int MedianOfThree(int[] arr, int left, int right)
        {
            int mid = left + (right - left) / 2;

            // Rearrange the elements to ensure the median is in the middle
            if (arr[left] > arr[mid])
                Swap(arr, left, mid);

            if (arr[left] > arr[right])
                Swap(arr, left, right);

            if (arr[mid] > arr[right])
                Swap(arr, mid, right);

            return arr[mid]; // Return the median value
        }
        #endregion

        #region QuickSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the QuickSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// QuickSort is a highly efficient sorting algorithm based on the divide-and-conquer strategy. It works by
        /// partitioning the array into two subarrays, based on a chosen pivot element, and recursively sorting the
        /// subarrays. The pivot element is positioned such that all elements to its left are smaller, and all elements
        /// to its right are greater.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O(n log n) - where n is the number of elements in the array. QuickSort has an average and
        /// best-case time complexity of O(n log n), making it one of the fastest sorting algorithms available. However,
        /// in the worst-case scenario (when the pivot is consistently chosen as the smallest or largest element),
        /// the time complexity can degrade to O(n^2).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(log n) - QuickSort operates recursively, consuming additional space on the call stack
        /// for each recursive call. The space complexity is determined by the maximum depth of the recursive calls, which is
        /// log n for an array of size n.
        /// </para>
        /// </remarks>
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1); // Call the private QuickSort method with initial left and right indices
        }

        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right); // Determine the pivot index through partitioning
                QuickSort(arr, left, pivot - 1); // Recursively sort the left partition
                QuickSort(arr, pivot + 1, right); // Recursively sort the right partition
            }
        }
        #endregion
    }
}
