namespace SortAlgorithmsLibrary
{
    public class DistributionSorts : SortAlgorithms
    {
        /// <summary>
        /// Sorts an array of integers in ascending order using the Radix Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Radix Sort is a non-comparative sorting algorithm that sorts elements based on their individual digits or
        /// radix. It works by distributing the elements into buckets based on the value of each digit, from the least
        /// significant digit to the most significant digit. Radix Sort is efficient for sorting integers with a fixed
        /// number of digits.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b> O(k * n) - where n is the number of elements in the array and k is the number of digits
        /// in the maximum value. Radix Sort has a linear time complexity, making it efficient for large arrays with a
        /// limited range of values.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(n) - Radix Sort operates in-place, requiring additional space for auxiliary arrays
        /// with sizes proportional to the number of elements in the input array.
        /// </para>
        /// </remarks>
        public static void RadixSort(int[] arr)
        {
            if (arr is null || arr.Length < 2)
            {
                return; // Base case: If the array is null or has less than 2 elements, it is already considered sorted
            }

            int max = GetMaxValue(arr); // Find the maximum value in the array

            for (int exp = 1; max / exp > 0; exp *= 10) // Perform Counting Sort for each digit position (from least significant to most significant)
            {
                CountingSort(arr, exp);
            }
        }

        private static void CountingSort(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n];
            int[] count = new int[19]; // Counting array for -9 to 9 (including 0)

            for (int i = 0; i < 19; i++) // Initialize the counting array to 0
            {
                count[i] = 0;
            }

            for (int i = 0; i < n; i++) // Count the occurrences of each digit in the current digit position
            {
                count[GetDigit(arr[i], exp)]++;
            }

            for (int i = 1; i < 19; i++) // Calculate the cumulative count array
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--) // Build the output array using the count array
            {
                output[count[GetDigit(arr[i], exp)] - 1] = arr[i];
                count[GetDigit(arr[i], exp)]--;
            }

            Array.Copy(output, arr, n); // Copy the sorted elements from the output array back to the original array
        }

        private static int GetDigit(int num, int exp)
        {
            // Extract the digit at the current digit position (exp) by performing integer division and modulo operations
            return (num / exp) % 10 + 9;
        }

        private static int GetMaxValue(int[] arr)
        {
            int max = arr[0];

            for (int i = 1; i < arr.Length; i++) // Find the maximum value in the array
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
