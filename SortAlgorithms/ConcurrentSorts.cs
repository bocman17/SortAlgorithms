using System.Collections.Concurrent;

namespace SortAlgorithmsLibrary
{
    public class ConcurrentSorts : SortAlgorithms
    {
        /// <summary>
        /// Sorts an array of integers in ascending order using the Bitonic Merge Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Bitonic Merge Sort is a parallel sorting algorithm that combines the concepts of bitonic sequences and merge sort.
        /// It is particularly suitable for parallel processing due to its inherent divide-and-conquer nature and the ability
        /// to perform multiple comparisons and swaps in parallel.
        /// </para>
        /// <para>
        /// The algorithm works by recursively dividing the array into two halves, each of which is sorted independently
        /// in a bitonic sequence (either ascending or descending). The two sorted halves are then merged using the bitonic
        /// merge operation, which combines two bitonic sequences into a single sorted sequence in the specified order
        /// (ascending or descending).
        /// </para>
        /// <para>
        /// The BitonicMergeSort method serves as the entry point for the algorithm, calling the BitonicSort method to
        /// recursively sort the array in a bitonic sequence. The BitonicMerge method is responsible for merging the sorted
        /// sequences using the bitonic merge operation.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log^2 n) - Bitonic Merge Sort has an average-case time complexity of O(n log^2 n),
        ///   where n is the size of the input array.
        /// - Worst Case: O(n log^2 n) - The worst-case time complexity of Bitonic Merge Sort is O(n log^2 n).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(log n) - The space complexity of Bitonic Merge Sort is determined by the stack space
        /// used for recursion, which is proportional to the logarithm of the input size.
        /// </para>
        /// </remarks>
        public static void BitonicMergeSort(int[] array)
        {
            BitonicSort(array, 0, array.Length, true);
        }

        private static void BitonicSort(int[] array, int low, int count, bool ascending)
        {
            if (count <= 1)
                return;

            int mid = count / 2;

            // Perform BitonicSort in parallel on the two halves of the array
            Parallel.Invoke(
                () => BitonicSort(array, low, mid, !ascending),
                () => BitonicSort(array, low + mid, count - mid, ascending)
            );

            // Merge the two sorted halves of the array
            BitonicMerge(array, low, count, ascending);
        }

        private static void BitonicMerge(int[] array, int low, int count, bool ascending)
        {
            if (count <= 1)
                return;

            // Find the greatest power of 2 that is less than the count
            int k = GreatestPowerOfTwoLessThan(count);

            // Perform parallel comparisons and swaps within bitonic sequences
            Parallel.For(low, low + count - k, i =>
            {
                if ((array[i] > array[i + k] && ascending) || (array[i] < array[i + k] && !ascending))
                {
                    Swap(array, i, i + k);
                }
            });

            // Recursively merge the remaining sub-sequences
            BitonicMerge(array, low, k, ascending);
            BitonicMerge(array, low + k, count - k, ascending);
        }

        private static int GreatestPowerOfTwoLessThan(int n)
        {
            int k = 1;
            while (k < n)
            {
                k <<= 1; // Left shift to find the next power of 2
            }
            return k >> 1; // Right shift to get the greatest power of 2 less than n
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the Batcher's Odd-Even Merge Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Batcher's Odd-Even Merge Sort is a parallel sorting algorithm based on the concept of odd-even merging
        /// of subarrays. It is particularly suitable for parallel processing due to its inherent divide-and-conquer nature
        /// and the ability to perform multiple merge operations in parallel.
        /// </para>
        /// <para>
        /// The algorithm works by recursively dividing the array into smaller subarrays until each subarray contains
        /// only one element. Then, it performs odd-even merging of adjacent subarrays to merge and sort them in ascending
        /// order. This process is repeated until the entire array is sorted.
        /// </para>
        /// <para>
        /// The BatcherOddEvenMergeSort method serves as the entry point for the algorithm, calling the OddEvenMergeSort
        /// method to recursively sort the array using odd-even merging. The OddEvenMerge method is responsible for merging
        /// adjacent subarrays in the odd-even pattern. The Merge method is used to perform the actual merging of subarrays.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log^2 n) - Batcher's Odd-Even Merge Sort has an average-case time complexity of O(n log^2 n),
        ///   where n is the size of the input array.
        /// - Worst Case: O(n log^2 n) - The worst-case time complexity of Batcher's Odd-Even Merge Sort is O(n log^2 n).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(n) - The space complexity of Batcher's Odd-Even Merge Sort is O(n) due to the use
        /// of an auxiliary array during the merging process.
        /// </para>
        /// </remarks> 
        public static void BatcherOddEvenMergeSort(int[] array)
        {
            int n = array.Length;
            OddEvenMergeSort(array, 0, n - 1);
        }

        private static void OddEvenMergeSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;

                // Recursively sort the two halves of the array in parallel
                Parallel.Invoke(
                    () => OddEvenMergeSort(array, low, mid),
                    () => OddEvenMergeSort(array, mid + 1, high)
                );

                // Merge the two sorted halves of the array
                OddEvenMerge(array, low, high);
            }
        }

        private static void OddEvenMerge(int[] array, int low, int high)
        {
            if (high > low)
            {
                int mid = low + (high - low) / 2;

                // Recursively merge adjacent pairs of elements in parallel
                Parallel.Invoke(
                    () => Merge(array, low, mid),
                    () => Merge(array, mid + 1, high)
                );

                // Merge the remaining sub-sequences
                Merge(array, low, high);
            }
        }

        private static void Merge(int[] array, int low, int high)
        {
            int mid = low + (high - low) / 2;
            int n = high - low + 1;
            int[] temp = new int[n];
            int i = low;
            int j = mid + 1;
            int k = 0;

            // Merge the two sorted sub-sequences into a temporary array
            while (i <= mid && j <= high)
            {
                if (array[i] <= array[j])
                {
                    temp[k++] = array[i++];
                }
                else
                {
                    temp[k++] = array[j++];
                }
            }

            // Copy any remaining elements from the first sub-sequence
            while (i <= mid)
            {
                temp[k++] = array[i++];
            }

            // Copy any remaining elements from the second sub-sequence
            while (j <= high)
            {
                temp[k++] = array[j++];
            }

            // Copy the sorted elements back to the original array
            Array.Copy(temp, 0, array, low, n);
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the Pairwise Sorting Network Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Pairwise Sorting Network Sort is a parallel sorting algorithm that leverages the concept of pairwise comparisons
        /// to sort the array. It is based on the idea of breaking down the sorting process into smaller subproblems and
        /// merging the results using pairwise merging operations.
        /// </para>
        /// <para>
        /// The algorithm works by recursively dividing the array into smaller subarrays until each subarray contains
        /// only one element. Then, it performs pairwise merging of adjacent subarrays to merge and sort them in ascending order.
        /// This process is repeated until the entire array is sorted.
        /// </para>
        /// <para>
        /// The PairwiseSortingNetworkSort method serves as the entry point for the algorithm, calling the SortPairwise
        /// method to recursively sort the array using pairwise merging. The MergePairwise method performs the pairwise merging
        /// operations by iteratively merging subarrays with increasing step sizes. The MergeSubArrays method is used to perform
        /// the actual merging of two subarrays.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log n) - Pairwise Sorting Network Sort has an average-case time complexity of O(n log n),
        ///   where n is the size of the input array.
        /// - Worst Case: O(n log n) - The worst-case time complexity of Pairwise Sorting Network Sort is O(n log n).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(n) - The space complexity of Pairwise Sorting Network Sort is O(n) due to the use
        /// of an auxiliary array during the merging process.
        /// </para>
        /// </remarks>
        public static void PairwiseSortingNetworkSort(int[] array)
        {
            int n = array.Length;
            SortPairwise(array, 0, n - 1);
        }

        private static void SortPairwise(int[] array, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;

                // Recursively sort the two halves of the array in parallel
                Parallel.Invoke(
                    () => SortPairwise(array, low, mid),
                    () => SortPairwise(array, mid + 1, high)
                );

                // Merge the two sorted halves using a pairwise merging algorithm
                MergePairwise(array, low, high);
            }
        }

        private static void MergePairwise(int[] array, int low, int high)
        {
            int length = high - low + 1;

            // Perform pairwise merging iteratively
            for (int step = 1; step < length; step *= 2)
            {
                // Merge sub-arrays pairwise in parallel
                Parallel.For(low, high - step + 1, i =>
                {
                    // Determine if the current sub-arrays should be merged based on their position
                    if (i % (2 * step) == low % (2 * step))
                    {
                        int mid = i + step - 1;
                        int end = Math.Min(i + 2 * step - 1, high);

                        // Merge the two sub-arrays into a temporary array
                        MergeSubArrays(array, i, mid, end);
                    }
                });
            }
        }

        private static void MergeSubArrays(int[] array, int low, int mid, int high)
        {
            int[] temp = new int[high - low + 1];

            int i = low;
            int j = mid + 1;
            int k = 0;

            // Merge the two sub-arrays into a temporary array
            while (i <= mid && j <= high)
            {
                if (array[i] <= array[j])
                {
                    temp[k] = array[i];
                    i++;
                }
                else
                {
                    temp[k] = array[j];
                    j++;
                }
                k++;
            }

            // Copy any remaining elements from the first sub-array
            while (i <= mid)
            {
                temp[k] = array[i];
                i++;
                k++;
            }

            // Copy any remaining elements from the second sub-array
            while (j <= high)
            {
                temp[k] = array[j];
                j++;
                k++;
            }

            // Copy the sorted elements back to the original array
            for (int x = 0; x < temp.Length; x++)
            {
                array[low + x] = temp[x];
            }
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the Sample Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Sample Sort is a parallel sorting algorithm that leverages the concept of sampling and partitioning to sort the array.
        /// It is designed to efficiently handle large arrays and takes advantage of parallelism to improve performance.
        /// </para>
        /// <para>
        /// The algorithm works by recursively dividing the array into smaller subranges until each subrange can be efficiently
        /// sorted using a sequential sorting algorithm (SmallSort). For larger subranges, the algorithm selects a set of splitters
        /// as representative elements and partitions the elements into buckets based on their values relative to the splitters.
        /// The buckets are then sorted independently in parallel using recursive calls to SampleSort. Finally, the sorted
        /// buckets are merged to obtain the sorted array.
        /// </para>
        /// <para>
        /// The SampleSort method serves as the entry point for the algorithm. It initializes the threshold value based on the
        /// number of available processors and sets up a concurrent stack to manage the subrange processing. The algorithm uses
        /// a stack-based approach to handle the recursive nature of the partitioning process, enabling efficient parallelism.
        /// The SmallSort method is used to sort small subranges using a simple sequential sorting algorithm. The SelectSplitters
        /// method selects representative splitters from each subrange, and the PartitionElements method partitions the elements
        /// into buckets based on the splitters. The sorting and merging of the buckets are performed in parallel using recursive
        /// calls to SampleSort.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log n) - Sample Sort has an average-case time complexity of O(n log n),
        ///   where n is the size of the input array.
        /// - Worst Case: O(n log n) - The worst-case time complexity of Sample Sort is O(n log n).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b>
        /// - Average Case: O(n) - The space complexity of Sample Sort is O(n) due to the additional arrays used for splitters,
        ///   bucket sizes, bucket indexes, and temporary storage during the merging process.
        /// - Worst Case: O(n) - In the worst case, Sample Sort has a space complexity of O(n) due to the same reasons as the
        ///   average case.
        /// </para>
        /// </remarks>
        public static void SampleSort(int[] array)
        {
            // Determine the threshold for when to switch to a small sort (e.g., insertion sort)
            int threshold = Environment.ProcessorCount;
            // Initialize the range to sort as the entire array
            int left = 0;
            int right = array.Length - 1;

            // Use a stack to keep track of the ranges that need to be sorted
            var stack = new ConcurrentStack<(int, int)>();
            stack.Push((left, right));

            while (stack.TryPop(out (int, int) currentRange))
            {
                // Extract the current range from the stack
                (left, right) = currentRange;

                // If the range is small enough, perform a simple insertion sort
                if (right - left < threshold)
                {
                    SmallSort(array, left, right);
                }
                else
                {
                    int p = Environment.ProcessorCount;

                    // Select splitters evenly from the range
                    int[] splitters = new int[p - 1];
                    SelectSplitters(array, left, right, splitters);

                    // Count the number of elements falling into each bucket
                    int[] bucketSizes = new int[p];
                    int[] bucketIndexes = new int[p];
                    PartitionElements(array, left, right, splitters, bucketSizes, bucketIndexes);

                    // Create subtasks to sort each bucket in parallel
                    Parallel.For(0, p, i =>
                    {
                        int bucketLeft = bucketIndexes[i];
                        int bucketRight = (i < p - 1) ? bucketIndexes[i + 1] - 1 : right;
                        stack.Push((bucketLeft, bucketRight));
                    });
                }
            }
        }

        private static void SmallSort(int[] array, int left, int right)
        {
            // A simple insertion sort for small ranges
            for (int i = left + 1; i <= right; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= left && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }

        private static void SelectSplitters(int[] array, int left, int right, int[] splitters)
        {
            Random random = new Random();

            // Determine the interval between splitters based on the range size
            int interval = (right - left + 1) / splitters.Length;

            // Randomly select elements from each interval as splitters
            for (int i = 0; i < splitters.Length; i++)
            {
                int index = random.Next(left + interval * i, left + interval * (i + 1));
                splitters[i] = array[index];
            }

            // Sort the selected splitters
            SmallSort(splitters, 0, splitters.Length - 1);
        }

        private static void PartitionElements(int[] array, int left, int right, int[] splitters, int[] bucketSizes, int[] bucketIndexes)
        {
            // Initialize the array to hold the number of elements in each bucket
            Array.Fill(bucketSizes, 0);

            // Count the number of elements falling into each bucket
            for (int i = left; i <= right; i++)
            {
                int bucket = GetBucket(array[i], splitters);
                bucketSizes[bucket]++;
            }

            // Calculate the starting index for each bucket
            bucketIndexes[0] = left;
            for (int i = 1; i < bucketIndexes.Length; i++)
            {
                bucketIndexes[i] = bucketIndexes[i - 1] + bucketSizes[i - 1];
            }

            // Create a copy of the bucket indexes to keep track of the current position within each bucket
            int[] bucketCurrentIndexes = new int[bucketIndexes.Length];
            Array.Copy(bucketIndexes, bucketCurrentIndexes, bucketIndexes.Length);

            int[] tempArray = new int[right - left + 1]; // Create a temporary array to hold the sorted elements

            // Place the elements into their respective buckets in the temporary array
            for (int i = left; i <= right; i++)
            {
                int bucket = GetBucket(array[i], splitters);
                int index = bucketCurrentIndexes[bucket] - left; // Adjust index relative to the left
                tempArray[index] = array[i];
                bucketCurrentIndexes[bucket]++;
            }

            // Copy the elements from the temporary array back to the original array
            Array.Copy(tempArray, 0, array, left, tempArray.Length);
        }


        private static int GetBucket(int value, int[] splitters)
        {
            int left = 0;
            int right = splitters.Length - 1;

            // Perform binary search to find the correct bucket for the value
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (value <= splitters[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return left;
        }
    }
}
