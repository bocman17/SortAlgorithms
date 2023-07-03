namespace SortAlgorithmsLibrary
{
    public class ImpracticalSorts : SortAlgorithms
    {
        /// <summary>
        /// Sorts an array of integers in ascending order using the BogoSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// BogoSort, also known as Permutation Sort or Stupid Sort, is a highly inefficient sorting algorithm.
        /// It works by repeatedly shuffling the elements randomly until the array becomes sorted.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O((n+1)!*n) - where n is the number of elements in the array. BogoSort has an
        /// average and worst-case time complexity of O((n+1)!*n), making it highly impractical for sorting large
        /// arrays. The algorithm's time complexity grows factorially with the number of elements.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - BogoSort operates in-place, requiring only a constant amount of extra space.
        /// </para>
        /// </remarks>
        public static void BogoSort(int[] arr)
        {
            Random random = new Random();
            while (!IsSorted(arr)) // Keep shuffling the array until it is sorted
            {
                Shuffle(arr, random);
            }
        }

        private static void Shuffle(int[] arr, Random random)
        {
            for (int i = arr.Length - 1; i > 0; i--) // Perform a Fisher-Yates shuffle on the array
            {
                int j = random.Next(i + 1); // Generate a random index between 0 and i (inclusive)
                Swap(arr, i, j); // Swap the elements at indices i and j
            }
        }

        private static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++) // Check if the array is sorted in ascending order
            {
                if (arr[i] < arr[i - 1]) // If any adjacent elements are out of order, return false
                {
                    return false;
                }
            }
            return true; // If all elements are in sorted order, return true
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the StoogeSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// StoogeSort is a recursive sorting algorithm that divides the array into three parts and recursively sorts
        /// the first two-thirds and last two-thirds of the array. Finally, it recursively sorts the first two-thirds
        /// again to ensure the entire array is sorted.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O(n^(log 3 / log 1.5)) - where n is the number of elements in the array. StoogeSort
        /// has a time complexity of O(n^(log 3 / log 1.5)), which is slightly worse than O(n^2). The recursive nature
        /// of the algorithm contributes to its relatively slower performance.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(log n) - StoogeSort operates recursively, consuming additional space on the call
        /// stack for each recursive call. The space complexity is determined by the maximum depth of the recursive calls,
        /// which is log n for an array of size n.
        /// </para>
        /// </remarks>
        public static void StoogeSort(int[] arr)
        {
            if(arr.Length < 2)
            {
                return; // Base case: If the array has less than 2 elements, it is already sorted
            }
            StoogeSort(arr, 0, arr.Length - 1);
        }

        private static void StoogeSort(int[] arr, int start, int end)
        {
            if (arr[start] > arr[end])
            {
                Swap(arr, start, end); // Swap the first and last elements if they are out of order
            }

            if (end - start + 1 > 2)
            {
                // Recursively sort the remaining unsorted portion of the array

                int third = (end - start + 1) / 3; // Calculate the index that divides the array into three equal parts

                StoogeSort(arr, start, end - third); // Sort the first two-thirds of the array
                StoogeSort(arr, start + third, end); // Sort the last two-thirds of the array
                StoogeSort(arr, start, end - third); // Sort the first two-thirds of the array again to ensure the entire array is sorted
            }
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the SlowSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// SlowSort is a recursive sorting algorithm that breaks down the array into smaller subarrays and compares
        /// adjacent elements to swap them if they are out of order. It continues this process recursively until the
        /// entire array is sorted.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O(n^4) - where n is the number of elements in the array. SlowSort has a time complexity
        /// of O(n^4), making it highly inefficient for larger arrays. It is mainly used for educational purposes to
        /// illustrate sorting algorithms.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(log n) - SlowSort operates recursively, consuming additional space on the call stack
        /// for each recursive call. The space complexity is determined by the maximum depth of the recursive calls,
        /// which is log n for an array of size n.
        /// </para>
        /// </remarks>
        public static void SlowSort(int[] arr)
        {
            SlowSort(arr, 0, arr.Length - 1); // Start the Slow Sort algorithm with the entire array
        }

        private static void SlowSort(int[] arr, int start, int end)
        {
            if(start >= end)
            {
                // Base case: If the start index is greater than or equal to the end index,
                // the range is empty or has a single element, which is already sorted
                return;
            }

            int mid = (start + end) / 2; // Calculate the middle index of the current range

            SlowSort(arr, start, mid); // Recursively sort the first half of the range
            SlowSort(arr, mid + 1, end); // Recursively sort the second half of the range

            if (arr[mid] > arr[end])
            {
                Swap(arr, mid, end); // If the element at the middle index is greater than the element at the end index, swap them
            }

            SlowSort(arr, start, end - 1); // Recursively sort the range excluding the last element
        }
    }
}
