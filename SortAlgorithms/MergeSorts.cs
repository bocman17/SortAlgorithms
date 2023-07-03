namespace SortAlgorithmsLibrary
{
    public class MergeSorts : SortAlgorithms
    {
        /// <summary>
        /// Sorts an array of integers in ascending order using the MergeSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// MergeSort is a divide-and-conquer algorithm that recursively divides the input array into two halves,
        /// sorts them independently, and then merges the sorted halves to produce the final sorted array.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log n) - MergeSort has an average-case time complexity of O(n log n) for most inputs.
        /// - Worst Case: O(n log n) - In the worst-case scenario, the time complexity is O(n log n).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(n) - MergeSort requires additional space to store the two halves of the array during the merge step.
        /// The space complexity is proportional to the input size.
        /// </para>
        /// </remarks>
        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1) // If the array length is 0 or 1, it is already sorted
            {
                return;
            }

            // Divide the array into two halves
            int middle = arr.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[arr.Length - middle];

            // Copy elements to the left and right arrays
            Array.Copy(arr, 0, left, 0, middle);
            Array.Copy(arr, middle, right, 0, arr.Length - middle);

            // Recursively sort the left and right halves
            MergeSort(left);
            MergeSort(right);

            Merge(arr, left, right); // Merge the sorted halves
        }

        private static void Merge(int[] mergedArr, int[] left, int[] right)
        {
            // Indices for tracking positions in left, right, and mergedArr arrays
            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = 0;

            // Merge the left and right arrays into mergedArr
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                // Compare the elements at the current indices and select the smaller one
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

                mergedIndex++; // Move to the next index in the mergedArr
            }

            // Append the remaining elements from the left array
            while (leftIndex < left.Length)
            {
                mergedArr[mergedIndex] = left[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            // Append the remaining elements from the right array
            while (rightIndex < right.Length)
            {
                mergedArr[mergedIndex] = right[rightIndex];
                rightIndex++;
                mergedIndex++;
            }
        }
    }
}
