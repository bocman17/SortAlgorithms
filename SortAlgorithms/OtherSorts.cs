namespace SortAlgorithmsLibrary
{
    public class OtherSorts : SortAlgorithms
    {
        /// <summary>
        /// Sorts an array of integers in ascending order using the PancakeSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// PancakeSort is a sorting algorithm that works by repeatedly flipping the largest unsorted element to the front
        /// until the array is sorted. It involves two main operations: finding the index of the maximum element and flipping
        /// the elements up to that index to reverse their order. By iteratively performing these operations, the array is
        /// sorted in ascending order.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n^2) - PancakeSort has an average-case time complexity of O(n^2) for most inputs.
        /// - Worst Case: O(n^2) - In the worst-case scenario, the time complexity is O(n^2) when the array is in reverse order.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - PancakeSort operates in-place, modifying the input array directly. It does not require
        /// additional space proportional to the input size.
        /// </para>
        /// </remarks>
        public static void PancakeSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = n - 1; i > 0; i--)
            {
                int maxIndex = FindMaxIndex(arr, i); // Find the index of the maximum element in the unsorted portion

                // If the maximum element is not already at the current position, flip the elements
                if (maxIndex != i)
                {
                    Flip(arr, maxIndex); // Flip the elements up to the maximum element index
                    Flip(arr, i); // Flip the elements up to the current position
                }
            }
        }

        private static void Flip(int[] arr, int index)
        {
            int start = 0;
            while (start < index)
            {
                Swap(arr, start, index);
                start++;
                index--;
            }
        }

        private static int FindMaxIndex(int[] arr, int end)
        {
            int maxIndex = 0;

            // Find the index of the maximum element in the range [0, end]
            for (int i = 1; i <= end; i++)
            {
                if (arr[i] > arr[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}
