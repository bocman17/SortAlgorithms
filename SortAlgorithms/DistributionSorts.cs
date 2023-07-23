using SortAlgorithms.HelperClasses;

namespace SortAlgorithmsLibrary
{
    public class DistributionSorts : SortAlgorithms
    {
        #region AmericanFlagSort

        /// <summary>
        /// Sorts an array of integers in ascending order using the American Flag Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// American Flag Sort is a variation of Counting Sort that is particularly useful when sorting arrays with a limited range of integer values.
        /// The algorithm works by counting the frequency of each value in the array and then placing the elements in the correct order in the output array.
        /// </para>
        /// <para>
        /// The algorithm starts by finding the minimum and maximum values in the input array, which defines the range of values to be sorted.
        /// It then creates a flag array of size equal to the range of values (max - min + 1) and an output array of the same size as the input array.
        /// </para>
        /// <para>
        /// The algorithm proceeds to count the frequency of each value in the input array by incrementing the corresponding position in the flag array.
        /// Each position in the flag array represents the number of occurrences of a specific value in the input array.
        /// </para>
        /// <para>
        /// Next, the algorithm computes the cumulative sum of the flag array. Each element in the cumulative sum represents the end index (exclusive)
        /// of a group of elements with the same value in the output array. This step ensures that elements with the same value appear together and in
        /// ascending order in the sorted output.
        /// </para>
        /// <para>
        /// Finally, the algorithm places the elements in the correct positions in the output array by scanning the input array in reverse order.
        /// For each element, it finds the corresponding position in the output array using the flag array and decrements the flag value to handle
        /// duplicate elements with the same value. The sorted elements are then copied back to the input array, resulting in the array being sorted
        /// in ascending order.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n + k) - American Flag Sort has an average-case time complexity of O(n + k), where n is the size of the input array,
        ///   and k is the range of values (max - min + 1). The counting and cumulative sum operations are linear with respect to the input size
        ///   and the range of values.
        /// - Worst Case: O(n + k) - The worst-case time complexity of American Flag Sort is also O(n + k), occurring when the input array contains
        ///   a wide range of values.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b>
        /// - Average Case: O(n + k) - The space complexity of American Flag Sort is O(n + k) due to the additional flag and output arrays of sizes
        ///   proportional to the input array and the range of values.
        /// - Worst Case: O(n + k) - In the worst case, American Flag Sort has a space complexity of O(n + k) due to the same reason as the average case.
        /// </para>
        /// </remarks>
        public static void AmericanFlagSort(int[] arr)
        {
            int n = arr.Length;
            if (n <= 1)
            {
                return;
            }

            int min = arr[0];
            int max = arr[0];

            // Find the minimum and maximum values in the array
            for (int i = 1; i < n; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                else if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            int range = max - min + 1;
            int[] flag = new int[range];
            int[] output = new int[n];

            // Count the frequency of each value in the array
            for (int i = 0; i < n; i++)
            {
                flag[arr[i] - min]++;
            }

            // Compute the cumulative sum of the flag array
            for (int i = 1; i < range; i++)
            {
                flag[i] += flag[i - 1];
            }

            // Place the elements in the correct position in the output array
            for (int i = n - 1; i >= 0; i--)
            {
                int value = arr[i];
                int index = flag[value - min]-- - 1;
                output[index] = value;
            }

            // Copy the sorted elements back to the input array
            Array.Copy(output, arr, n);
        }
        #endregion

        #region BeadSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the Bead Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Bead Sort, also known as Gravity Sort or Pool Sort, is a simple sorting algorithm that operates on integers.
        /// It is based on a physical analogy of beads (or balls) falling under gravity. The algorithm sorts the elements by simulating
        /// the process of beads falling into bins or tubes. It is efficient for sorting small sets of non-negative integers with
        /// a relatively small range of values.
        /// </para>
        /// <para>
        /// The algorithm begins by finding the minimum value in the input array, which is used to transform the input array to non-negative
        /// integers to work with the Bead Sort algorithm. It then proceeds to create an array of "beads" or bins, where each element in the
        /// input array represents the number of beads in the corresponding bin.
        /// </para>
        /// <para>
        /// During each pass through the bins, the algorithm simulates the process of dropping beads from each bin. The number of beads
        /// dropped from each bin corresponds to the value of the bin, and they accumulate in the lower bins, creating a sorted stack of beads
        /// in each column. This process is repeated until all beads have been dropped, and the beads' arrangement in the bins represents
        /// the sorted order of the input elements.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n + m), where n is the size of the input array, and m is the maximum value in the input array. Bead Sort has
        ///   an average-case time complexity of O(n + m) since it involves two passes through the input array and a loop with m iterations
        ///   (the maximum value).
        /// - Worst Case: O(n + m), the worst-case time complexity of Bead Sort is also O(n + m), which occurs when there are no duplicate
        ///   elements, and each bead needs to be dropped individually.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b>
        /// - Average Case: O(n + m), the space complexity of Bead Sort is O(n + m) due to the additional beads array of size n and
        ///   the modifiedArr array of size n.
        /// - Worst Case: O(n + m), in the worst case, Bead Sort has a space complexity of O(n + m) due to the same reasons as the average case.
        /// </para>
        /// </remarks>
        public static void BeadSort(int[] arr)
        {
            // If the array has 0 or 1 element, it is already sorted, so return early
            if (arr.Length <= 1)
            {
                return;
            }
            // Find the minimum value in the array
            int min = arr.Min();

            // Subtract the minimum value from each element to make all values non-negative
            int[] modifiedArr = arr.Select(x => x - min).ToArray();

            // Call the ModifiedBeadSort algorithm on the modified array
            ModifiedBeadSort(modifiedArr);

            // Restore the original values by adding the minimum value back to each element
            for (int i = 0; i < modifiedArr.Length; i++)
            {
                arr[i] = modifiedArr[i] + min;
            }
        }

        // Modified Bead Sort algorithm to sort the modified array
        private static void ModifiedBeadSort(int[] arr)
        {
            int n = arr.Length;

            // Find the maximum value in the array
            int maximum = arr.Max();

            // Create a 2D array of "beads," where each row represents a value in the array,
            // and the number of beads in each row corresponds to the value of the element in the array
            int[][] beads = new int[n][];

            for (int i = 0; i < n; i++)
            {
                beads[i] = new int[maximum];

                // Place beads in each row corresponding to the value of the element
                for (int j = 0; j < arr[i]; j++)
                {
                    beads[i][j] = 1;
                }
            }

            // Now, we simulate the dropping of beads through each column (representing values)
            for (int j = 0; j < maximum; j++)
            {
                int dropBeadsByColumn = 0;

                // Count the number of beads in each column and clear the column
                for (int i = 0; i < n; i++)
                {
                    dropBeadsByColumn += beads[i][j];
                    beads[i][j] = 0;
                }

                // Place beads in each column starting from the last row
                for (int i = n - 1; i >= n - dropBeadsByColumn; i--)
                {
                    beads[i][j] = 1;
                }

                // Update the array with the number of beads in each row, which corresponds to the sorted value
                for (int i = 0; i < n; i++)
                {
                    int numBeadsInRow = beads[i].Count(b => b == 1);
                    arr[i] = numBeadsInRow;
                }
            }
        }
        #endregion

        #region BucketSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the Bucket Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Bucket Sort is a sorting algorithm that works by distributing the elements of an array into a number of buckets (or containers),
        /// then individually sorting the buckets and concatenating them back into the original array. It is an efficient sorting algorithm
        /// for a uniform distribution of elements across a range and is well-suited for sorting floating-point numbers or integers with a relatively
        /// small range. The efficiency of Bucket Sort is influenced by the choice of the number of buckets and the sorting algorithm used for
        /// each bucket. In this implementation, a simple List-based insertion sort is used to sort each bucket.
        /// </para>
        /// <para>
        /// The algorithm starts by finding the minimum and maximum values in the input array to determine the range of values. It then creates
        /// an array of empty buckets to hold the elements. Each element in the input array is distributed into its corresponding bucket based on its
        /// value. The number of buckets and their ranges are determined by the range of values in the input array. The elements within each bucket
        /// are then sorted using an efficient sorting algorithm (in this case, a simple insertion sort) or any other suitable sorting algorithm.
        /// Finally, the sorted elements are concatenated back into the original array, resulting in a sorted array.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n + k), where n is the size of the input array, and k is the number of buckets. The average-case time complexity of
        ///   Bucket Sort is O(n + k), as distributing the elements into buckets takes O(n) time, and the insertion sort for each bucket takes
        ///   O(k*(n/k)log(n/k)) time (where k*(n/k) is the average number of elements in each bucket).
        /// - Worst Case: O(n^2), the worst-case time complexity of Bucket Sort can be O(n^2) when the elements are unevenly distributed into
        ///   buckets. If a bucket contains a large number of elements, sorting that bucket could take quadratic time.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b>
        /// - Average Case: O(n + k), the space complexity of Bucket Sort is O(n + k) due to the additional space used to store the buckets and
        ///   the input elements.
        /// - Worst Case: O(n + k), in the worst case, Bucket Sort has a space complexity of O(n + k) due to the same reasons as the average case.
        /// </para>
        /// </remarks>
        public static void BucketSort(int[] arr)
        {
            int n = arr.Length;
            if (n <= 1)
            {
                return;
            }

            // Find the minimum and maximum values in the array
            int min = arr.Min();
            int max = arr.Max();

            // Create empty buckets
            int numBuckets = Math.Max(n, max - min + 1);
            List<int>[] buckets = new List<int>[numBuckets];

            // Initialize empty buckets
            for (int i = 0; i < numBuckets; i++)
            {
                buckets[i] = new List<int>();
            }

            // Distribute elements into buckets
            for (int i = 0; i < n; i++)
            {
                int bucketIndex = GetBucketIndex(arr[i], min, max, numBuckets);
                buckets[bucketIndex].Add(arr[i]);
            }

            // Sort the elements within each bucket
            for (int i = 0; i < numBuckets; i++)
            {
                buckets[i].Sort();
            }

            // Concatenate the sorted elements from all the buckets
            int index = 0;
            for (int i = 0; i < numBuckets; i++)
            {
                foreach (int element in buckets[i])
                {
                    arr[index] = element;
                    index++;
                }
            }
        }

        private static int GetBucketIndex(int value, int min, int max, int numBuckets)
        {
            int adjustedValue = value - min;
            int range = max - min;

            if (range == 0)
            {
                return 0; // All elements are the same, so put them in the first bucket
            }

            int bucketIndex = (int)((long)adjustedValue * (numBuckets - 1) / range);
            return bucketIndex;
        }
        #endregion

        #region CountingSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the Counting Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Counting Sort is a non-comparison based sorting algorithm that works by counting the occurrence of each unique element in the input array
        /// and then determining the correct position of each element in the sorted output array. It is well-suited for sorting integers or other
        /// data types with a limited range of values. Counting Sort operates by creating an auxiliary count array to store the occurrence of each
        /// value in the input array. After counting the occurrence of each value, it modifies the count array to store the cumulative sum. The
        /// cumulative sum gives the correct position of each element in the sorted output array. Counting Sort then constructs the sorted output
        /// array based on the cumulative sum of the count array.
        /// </para>
        /// <para>
        /// The algorithm first finds the minimum and maximum values in the input array to determine the range of values. It then creates a count
        /// array with a length equal to the range of values. The count array is used to store the occurrence of each unique value in the input array.
        /// Each element in the input array is mapped to the count array based on its value, and the count array is updated to store the count of
        /// each value. The count array is then modified to store the cumulative sum of the counts, which provides the correct position for each
        /// value in the sorted output array. Finally, a temporary output array is used to place the elements in their correct sorted positions based
        /// on the cumulative sum of the count array. The sorted elements are then copied back to the original input array, resulting in a sorted array.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n + k), where n is the size of the input array, and k is the range of values. Counting Sort has an average-case time
        ///   complexity of O(n + k) because counting the occurrence of each value takes O(n) time, and modifying the count array to store the
        ///   cumulative sum takes O(k) time.
        /// - Worst Case: O(n + k), the worst-case time complexity of Counting Sort is O(n + k), which occurs when the input elements are uniformly
        ///   distributed across the range of values. The time complexity remains the same as the average case, but in the worst case, the constant
        ///   factors might be larger.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b>
        /// - Average Case: O(n + k), the space complexity of Counting Sort is O(n + k) due to the additional space used to store the count array
        ///   and the output array.
        /// - Worst Case: O(n + k), the worst-case space complexity of Counting Sort is O(n + k), which occurs when the input elements are uniformly
        ///   distributed across the range of values, resulting in the same space complexity as the average case.
        /// </para>
        /// </remarks>
        public static void CountingSort(int[] arr)
        {
            int n = arr.Length;
            if(n <= 1)
            {
                return;
            }

            // Find the maximum and minimum values in the array
            int max = arr.Max();
            int min = arr.Min();

            int range = max - min + 1;

            // Create a count array to store the occurrence of each value
            int[] count = new int[range];

            // Count the occurrence of each value
            for (int i = 0; i < n; i++)
            {
                count[arr[i] - min]++;
            }

            // Modify the count array to store the cumulative sum
            for (int i = 1; i < range; i++)
            {
                count[i] += count[i - 1];
            }

            // Create a temporary output array
            int[] output = new int[n];

            // Place the elements in the output array according to their positions
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[arr[i] - min] - 1] = arr[i];
                count[arr[i] - min]--;
            }

            // Copy the sorted elements from the output array to the original array
            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }
        #endregion

        #region FlashSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the FlashSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// FlashSort is an efficient non-comparison based sorting algorithm that works best when there is a significant number of duplicate elements
        /// in the input array. The algorithm takes advantage of the distribution of values in the input array to perform a counting-like operation
        /// and then places the elements in their correct sorted positions. FlashSort has a time complexity of O(n) for most cases, making it a fast
        /// sorting algorithm for certain distributions of data.
        /// </para>
        /// <para>
        /// The algorithm starts by finding the minimum and maximum values in the input array to determine the range of values. It then calculates
        /// a constant value 'c' to distribute the elements into 'm' classes based on their relative positions in the range. The 'm' classes are used
        /// as index buckets for a counting-like operation. The algorithm creates an array 'L' of size 'm' and initializes all elements to zero.
        /// It counts the occurrences of each class in the input array by incrementing the corresponding index in 'L' as it traverses the array.
        /// After the counting-like operation, it modifies 'L' to store the cumulative sum of the counts, which provides the correct position for each
        /// class in the sorted output array. Finally, it places the elements in their sorted positions in a temporary array 'sortedArr' and performs
        /// an insertion sort on the remaining elements.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n + m), where n is the size of the input array, and m is the number of classes. In most cases, 'm' is small compared to 'n',
        ///   making the time complexity of FlashSort close to linear.
        /// - Worst Case: O(n^2), the worst-case time complexity of FlashSort occurs when all elements fall into a single class, resulting in the same
        ///   time complexity as the insertion sort.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b>
        /// - Average Case: O(n + m), the space complexity of FlashSort is O(n + m), where n is the size of the input array, and m is the number of classes.
        ///   The algorithm uses additional space to store the count array 'L' and the temporary array 'sortedArr'.
        /// - Worst Case: O(n + m), the worst-case space complexity of FlashSort also occurs when all elements fall into a single class, resulting in the
        ///   same space complexity as the average case.
        /// </para>
        /// </remarks>
        public static void FlashSort(int[] arr)
        {
            int n = arr.Length;
            if (n <= 1)
            {
                // If the array has 0 or 1 element, it is already sorted, so return early
                return;
            }

            // Find the minimum and maximum values in the array
            int minVal = arr.Min();
            int maxVal = arr.Max();

            // Determine the number of elements to be sampled (m) for the histogram
            int m = (int)(0.45 * n);

            // Create the histogram array L to count occurrences of values in specific ranges
            int[] L = new int[m];
            for (int i = 0; i < m; i++)
                L[i] = 0;

            // If all elements in the array are the same, no sorting is needed, so return early
            if (minVal == maxVal)
                return;

            // Compute the scaling factor c for mapping array elements to histogram positions
            double c = (double)(m - 1) / (maxVal - minVal);

            // Count occurrences of values in the histogram ranges
            for (int i = 0; i < n; i++)
            {
                int k = (int)(c * (arr[i] - minVal));
                L[k]++;
            }

            // Compute the cumulative sum in the histogram array
            for (int i = 1; i < m; i++)
                L[i] += L[i - 1];

            // Create a sorted array to hold the final sorted elements
            int[] sortedArr = new int[n];

            // Distribute the elements into the sorted array using the histogram
            for (int i = n - 1; i >= 0; i--)
            {
                int k = (int)(c * (arr[i] - minVal));
                sortedArr[--L[k]] = arr[i];
            }

            // Perform an insertion sort for the remaining elements in the sorted array
            for (int i = 1; i < n; i++)
            {
                int key = sortedArr[i];
                int j = i - 1;

                while (j >= 0 && sortedArr[j] > key)
                {
                    sortedArr[j + 1] = sortedArr[j];
                    j--;
                }

                sortedArr[j + 1] = key;
            }

            // Copy the sorted elements from the temporary sorted array back to the original array
            Array.Copy(sortedArr, arr, n);
        }
        #endregion

        #region InterpolationSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the InterpolationSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// InterpolationSort is a variant of the BucketSort algorithm that takes advantage of the distribution of values in the input array
        /// to improve performance. It works best when the range of values in the input array is not too large. The algorithm calculates an
        /// "interpolation" value for each element in the array, which is a relative position of the element within the range of values. It then
        /// distributes the elements into buckets based on their interpolation values and recursively sorts elements within each bucket.
        /// Finally, it merges the sorted elements back into the original array.
        /// </para>
        /// <para>
        /// The algorithm starts by finding the minimum and maximum values in the input array to determine the range of values. If the minimum and
        /// maximum values are the same, the array is already sorted, and the algorithm returns immediately. Otherwise, it creates an array of
        /// "buckets" to hold the elements. Each bucket corresponds to a range of interpolation values, and the number of buckets is equal to the
        /// size of the input array. The algorithm then distributes each element into the appropriate bucket based on its interpolation value.
        /// The interpolation value for each element is calculated as the relative position of the element within the range of values, normalized
        /// to fit within the size of the input array minus one.
        /// </para>
        /// <para>
        /// After distributing the elements into buckets, the algorithm recursively applies InterpolationSort to each non-empty bucket with more
        /// than one element. This step is essential because it ensures that the elements within each bucket are correctly sorted. Finally, the
        /// sorted elements are merged back into the original array in ascending order.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n + k), where n is the size of the input array and k is the number of buckets. The average time complexity of
        ///   InterpolationSort is close to linear, but it may degrade to O(n^2) in certain cases with large ranges of values or skewed
        ///   distributions of elements.
        /// - Worst Case: O(n^2), the worst-case time complexity of InterpolationSort occurs when all elements are placed into a single bucket,
        ///   resulting in the same time complexity as the insertion sort.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b>
        /// - Average Case: O(n), the space complexity of InterpolationSort is O(n) because it creates an array of buckets, which is the same size as
        ///   the input array.
        /// - Worst Case: O(n), the worst-case space complexity of InterpolationSort also occurs when all elements fall into a single bucket, resulting
        ///   in the same space complexity as the average case.
        /// </para>
        /// </remarks>
        public static void InterpolationSort(int[] arr)
        {
            int size = arr.Length;
            if(size <= 1)
            {
                return;
            }
            int start = 0;
            int min = arr.Min();
            int max = arr.Max();

            if (min != max)
            {
                int[][] bucket = new int[size][];
                for (int i = 0; i < size; i++) { bucket[i] = new int[0]; }

                // Distribute elements into buckets based on their values
                for (int i = 0; i < size; i++)
                {
                    int interpolation = (int)(((double)arr[i] - min) / (max - min) * (size - 1));
                    Array.Resize(ref bucket[interpolation], bucket[interpolation].Length + 1);
                    bucket[interpolation][bucket[interpolation].Length - 1] = arr[i];
                }

                // Recursively sort elements within each bucket and merge them back into the original array
                for (int i = 0; i < size; i++)
                {
                    if (bucket[i].Length > 1) { InterpolationSort(bucket[i]); }
                    for (int j = 0; j < bucket[i].Length; j++) { arr[start++] = bucket[i][j]; }
                }
            }
        }
        #endregion

        #region PigeonholeSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the PigeonholeSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// PigeonholeSort is an integer sorting algorithm that works by distributing the elements of the input array into "pigeonholes" or "buckets"
        /// based on their values and then extracting the elements from the pigeonholes in ascending order. The algorithm assumes that the input
        /// elements are integers and that their values fall within a relatively small range compared to the size of the input array.
        /// </para>
        /// <para>
        /// The algorithm starts by finding the minimum and maximum values in the input array to determine the range of values. It then creates an
        /// array of "pigeonholes" to hold the counts of each distinct value in the input array. The number of pigeonholes is equal to the range of
        /// values (max - min + 1). The algorithm then scans the input array and increments the count in the corresponding pigeonhole for each
        /// encountered value.
        /// </para>
        /// <para>
        /// After counting the occurrences of each value in the input array, the algorithm proceeds to extract the elements from the pigeonholes
        /// and place them back into the original array in ascending order. It does this by iterating through the pigeonholes in ascending order
        /// of their values and extracting the elements while maintaining the sorted order.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n + range), where n is the size of the input array and range is the difference between the maximum and minimum values
        ///   in the input array. The average time complexity of PigeonholeSort is considered linear when the range is small compared to the size of
        ///   the input array.
        /// - Worst Case: O(n + range), the worst-case time complexity of PigeonholeSort occurs when all elements fall into a single pigeonhole,
        ///   resulting in the same time complexity as counting sort.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b>
        /// - Average Case: O(range), the space complexity of PigeonholeSort is determined by the range of values in the input array, as it needs
        ///   to create an array of pigeonholes, each representing a distinct value in the input array.
        /// - Worst Case: O(range), the worst-case space complexity of PigeonholeSort also occurs when all elements fall into a single pigeonhole,
        ///   resulting in the same space complexity as the average case.
        /// </para>
        /// </remarks>
        public static void PigeonholeSort(int[] arr)
        {
            int n = arr.Length;

            // If the array has 0 or 1 element, it is already sorted, so return early
            if (n <= 1)
            {
                return;
            }

            // Find the minimum and maximum values in the array
            int min = arr.Min();
            int max = arr.Max();
            int range, i, j, index;

            // Calculate the range of values in the array
            range = max - min + 1;

            // Create an array to hold the frequency (count) of each value in the original array
            int[] phole = new int[range];

            // Initialize the phole array with zeros
            for (i = 0; i < n; i++)
                phole[i] = 0;

            // Count the occurrences of each value and store the frequency in the phole array
            for (i = 0; i < n; i++)
                phole[arr[i] - min]++;

            // Index to keep track of the position to update the original array
            index = 0;

            // Reconstruct the sorted array by putting elements back into the original array
            for (j = 0; j < range; j++)

                // While the frequency of the value is greater than zero, put the value back into the original array
                while (phole[j]-- > 0)
                    arr[index++] = j + min;

        }
        #endregion

        #region ProxMapSort
        /// <summary>
        /// Sorts an array of integers in ascending order using the ProxMapSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// ProxMapSort is an integer sorting algorithm that works by mapping the elements of the input array into "proximity maps" based on their
        /// relative positions within the minimum and maximum values in the input array. It utilizes two optimizations to achieve a linear time
        /// complexity under certain conditions. ProxMapSort is most efficient when the input array contains a large number of repeated values or
        /// when the range of values is small compared to the size of the array.
        /// </para>
        /// <para>
        /// The algorithm starts by finding the minimum and maximum values in the input array to determine the range of values. It then creates
        /// an array of "proximity maps" (A2) and two auxiliary arrays (MapKey and hitCount). The proximity maps are used to store the elements
        /// in their correct sorted order, while the MapKey array stores the mapping of each element to its corresponding proximity map. The
        /// hitCount array is used to optimize the mapping process and minimize the number of comparisons.
        /// </para>
        /// <para>
        /// The algorithm proceeds with two optimization steps:
        /// </para>
        /// <para>
        /// <b>Optimization 1:</b>
        /// Calculate the MapKey for each element in the input array, which represents the index of the corresponding proximity map (A2) where the
        /// element should be placed. The hitCount array is used to count the occurrences of each proximity map index in the MapKey array. This
        /// optimization helps in identifying the positions for inserting elements into the proximity maps.
        /// </para>
        /// <para>
        /// <b>Optimization 2:</b>
        /// Compute the starting positions for each proximity map in the hitCount array. This optimization helps in efficiently inserting elements
        /// into the correct position in the proximity maps, avoiding unnecessary comparisons and reducing the overall time complexity.
        /// </para>
        /// <para>
        /// The algorithm then proceeds with the main sorting process, inserting elements from the input array into their corresponding proximity
        /// maps (A2) while maintaining the sorted order. Finally, the sorted elements are copied back to the original input array, completing
        /// the sorting process.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n + m), where n is the size of the input array and m is the range of values (max - min) in the input array. The
        ///   ProxMapSort algorithm achieves a linear time complexity under certain conditions, making it efficient for arrays with a large number
        ///   of repeated values or a small range of values compared to the array size.
        /// - Worst Case: O(n + m), the worst-case time complexity occurs when all elements fall into the same proximity map, resulting in the same
        ///   time complexity as counting sort.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b>
        /// - Average Case: O(n + m), the space complexity of ProxMapSort is determined by the size of the input array (n) and the range of values
        ///   (m) in the input array. The algorithm requires additional space to create the proximity maps and auxiliary arrays.
        /// - Worst Case: O(n + m), the worst-case space complexity of ProxMapSort also occurs when all elements fall into the same proximity map,
        ///   resulting in the same space complexity as the average case.
        /// </para>
        /// </remarks>
        public static void ProxMapSort(int[] arr)
        {
            int start = 0;
            int end = arr.Length;

            // If the array has 0 or 1 element, it is already sorted, so return early
            if (end <= 1)
            {
                return;
            }

            // Create arrays to store MapKey and hitCount for each element in the array
            int[] A2 = new int[end]; // A temporary array to store the sorted elements
            int[] MapKey = new int[end]; // Store the MapKey value for each element
            int[] hitCount = new int[end]; // Store the hitCount for each MapKey

            // Initialize hitCount array with zeros
            for (int i = start; i < end; i++)
            {
                hitCount[i] = 0;
            }

            // Find the minimum and maximum values in the array
            int min = arr.Min();
            int max = arr.Max();

            // Calculate the MapKey value for each element and update the hitCount array
            for (int i = start; i < end; i++)
            {
                // Calculate the MapKey based on the range and number of elements
                MapKey[i] = (int)Math.Floor(((double)(arr[i] - min) / (max - min)) * (end - 1));

                // Update the hitCount for the corresponding MapKey
                hitCount[MapKey[i]]++;
            }

            // Optimize the hitCount array to store ProxMaps
            hitCount[end - 1] = end - hitCount[end - 1];
            for (int i = end - 1; i > start; i--)
            {
                hitCount[i - 1] = hitCount[i] - hitCount[i - 1];
            }

            // Construct the sorted array by inserting elements into A2 at the correct positions
            for (int i = start; i < end; i++)
            {
                // Find the correct position to insert arr[i] in A2
                int insertIndex = hitCount[MapKey[i]];
                int insertStart = insertIndex;

                // Move elements in A2 to make space for the new element
                while (A2[insertIndex] != 0)
                {
                    insertIndex++;
                }
                while (insertIndex > insertStart && arr[i] < A2[insertIndex - 1])
                {
                    A2[insertIndex] = A2[insertIndex - 1];
                    insertIndex--;
                }

                // Insert arr[i] at the correct position in A2
                A2[insertIndex] = arr[i];
            }

            // Copy the sorted elements from A2 back to the original array
            Array.Copy(A2, arr, end);
        }
        #endregion

        #region RadixSort
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
        #endregion
    }
}
