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

        /// <summary>
        /// Sorts an array of integers in ascending order using the Spaghetti Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Spaghetti Sort is a simple and inefficient sorting algorithm that works by treating the elements of the array as spaghetti rods.
        /// The algorithm simulates the process of arranging the rods in order to sort the array.
        /// </para>
        /// <para>
        /// The algorithm starts by finding the minimum value in the array. It then shifts all the values in the array to make them positive,
        /// ensuring that the minimum value becomes zero. Next, it creates an auxiliary array of the same size as the input array to represent
        /// the spaghetti rods. Each rod in the auxiliary array has a length corresponding to the value of the corresponding element in the input array.
        /// </para>
        /// <para>
        /// The algorithm proceeds to sort the rods by repeatedly finding the longest rod and moving it to the front of the array. It does this
        /// by iterating over the auxiliary array and identifying the rod with the maximum length. The longest rod is removed from its position
        /// and inserted at the front of the array, simulating the act of arranging the rods in order of length. This process is repeated until
        /// all the rods have been sorted.
        /// </para>
        /// <para>
        /// Finally, the sorted rod lengths are copied back to the input array, and the values are shifted back to their original range by adding
        /// the minimum value that was subtracted earlier. The result is a sorted array in ascending order.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n^2) - Spaghetti Sort has an average-case time complexity of O(n^2), where n is the size of the input array.
        /// - Worst Case: O(n^2) - The worst-case time complexity of Spaghetti Sort is O(n^2), occurring when the input array is in reverse order.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b>
        /// - Average Case: O(n) - The space complexity of Spaghetti Sort is O(n) due to the auxiliary array used to represent the spaghetti rods.
        /// - Worst Case: O(n) - In the worst case, Spaghetti Sort has a space complexity of O(n) due to the same reason as the average case.
        /// </para>
        /// </remarks>
        public static void SpaghettiSort(int[] array)
        {
            int n = array.Length;

            // Find the minimum value in the array
            int minValue = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            // Shift all values to make them positive
            for (int i = 0; i < n; i++)
            {
                array[i] -= minValue;
            }

            // Create an array of spaghetti rods
            int[] rods = new int[n];

            // Obtain rods of appropriate lengths
            for (int i = 0; i < n; i++)
            {
                rods[i] = array[i];
            }

            // Sort the rods
            for (int i = 0; i < n; i++)
            {
                int longestRod = 0;
                int longestIndex = 0;

                // Find the longest rod
                for (int j = 0; j < n - i; j++)
                {
                    if (rods[j] > longestRod)
                    {
                        longestRod = rods[j];
                        longestIndex = j;
                    }
                }

                // Remove the longest rod and insert it at the front
                for (int j = longestIndex; j < n - i - 1; j++)
                {
                    rods[j] = rods[j + 1];
                }

                rods[n - i - 1] = longestRod;
            }

            // Copy the sorted rods back to the input array
            Array.Copy(rods, array, n);

            // Shift the values back to their original range
            for (int i = 0; i < n; i++)
            {
                array[i] += minValue;
            }
        }
    }
}
