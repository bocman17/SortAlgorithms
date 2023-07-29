namespace SortAlgorithmsLibrary
{
    public class MergeSorts : SortAlgorithms
    {
        #region MergeSort

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
        #endregion

        #region PolyphaseMergeSort

        private static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        private static void Merge(int[] arr, int[][] source, int leftStart, int leftEnd, int rightStart, bool sourceIsArr)
        {
            int i = leftStart;
            int j = rightStart;
            int k = leftStart;

            if (sourceIsArr)
            {
                while (i <= leftEnd && j < arr.Length)
                {
                    if (source[0][i] <= arr[j])
                    {
                        arr[k++] = source[0][i++];
                    }
                    else
                    {
                        arr[k++] = arr[j++];
                    }
                }

                while (i <= leftEnd)
                {
                    arr[k++] = source[0][i++];
                }
            }
            else
            {
                while (i < arr.Length && j <= leftEnd)
                {
                    if (arr[i] <= source[1][j])
                    {
                        arr[k++] = arr[i++];
                    }
                    else
                    {
                        arr[k++] = source[1][j++];
                    }
                }

                while (i < arr.Length)
                {
                    arr[k++] = arr[i++];
                }
            }
        }



        public static void PolyphaseMergeSort(int[] arr)
        {
            int blockSize = 8; // Adjust the blockSize as needed
            int numBlocks = (int)Math.Ceiling(arr.Length / (double)blockSize);
            int[][] blocks = new int[2][];
            blocks[0] = new int[blockSize];
            blocks[1] = new int[blockSize];

            // Step 1: Create initial sorted runs of blockSize
            int leftEnd = 0;
            int rightEnd = 0;
            bool sourceIsArr = true;

            for (int i = 0; i < numBlocks; i += 2)
            {
                int leftStart = i * blockSize;
                leftEnd = Math.Min(leftStart + blockSize - 1, arr.Length - 1);

                int rightStart = leftEnd + 1;
                rightEnd = Math.Min(rightStart + blockSize - 1, arr.Length - 1);

                if (rightStart <= rightEnd)
                {
                    Array.Copy(arr, leftStart, blocks[0], 0, blockSize);
                    Array.Copy(arr, rightStart, blocks[1], 0, blockSize);

                    InsertionSort(blocks[0]);
                    InsertionSort(blocks[1]);

                    Merge(arr, blocks, leftStart, leftEnd, rightStart, sourceIsArr);
                }
            }

            // Step 2: Merge remaining runs
            int totalRuns = numBlocks;
            sourceIsArr = false;

            while (totalRuns < arr.Length)
            {
                int runsToMerge = Math.Min(totalRuns, numBlocks);
                int destIndex = 0;

                for (int i = 0; i < runsToMerge; i += 2)
                {
                    int leftStart = i * blockSize;
                    leftEnd = Math.Min(leftStart + blockSize - 1, arr.Length - 1);

                    int rightStart = leftEnd + 1;
                    rightEnd = Math.Min(rightStart + blockSize - 1, arr.Length - 1);

                    if (rightStart <= rightEnd)
                    {
                        Array.Copy(arr, leftStart, blocks[0], 0, blockSize);
                        Array.Copy(arr, rightStart, blocks[1], 0, blockSize);

                        Merge(arr, blocks, leftStart, leftEnd, rightStart, sourceIsArr);
                        destIndex = rightEnd;
                    }
                    else
                    {
                        // Copy the remaining run back to the destination array
                        Array.Copy(arr, leftStart, arr, destIndex, blockSize);
                    }
                }

                totalRuns += runsToMerge;
                sourceIsArr = !sourceIsArr;
            }
        }


        #endregion
    }
}
