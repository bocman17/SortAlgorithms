using SortAlgorithms.HelperClasses;
using System.Xml.Linq;
using System;

namespace SortAlgorithmsLibrary
{
    public class InsertionSorts : SortAlgorithms
    {
        /// <summary>
        /// Sorts an array of integers in ascending order using the InsertionSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// InsertionSort is an in-place comparison-based sorting algorithm that builds the final sorted array one element at a time.
        /// It iterates over the array and, for each element, inserts it into its correct position in the already sorted portion of the array.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n^2) - InsertionSort has an average-case time complexity of O(n^2) for most inputs.
        /// - Worst Case: O(n^2) - In the worst-case scenario, the time complexity is O(n^2).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - InsertionSort operates directly on the input array and does not require additional space
        /// beyond a few variables to store temporary values and loop indices. The space complexity is constant.
        /// </para>
        /// </remarks>
        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length; // Get the length of the array

            for (int i = 1; i < n; i++) // Iterate over each element starting from the second element
            {
                int temp = arr[i]; // Store the current element in a temporary variable
                int j = i - 1; // Initialize a variable to track the position to insert the current element

                // Shift elements greater than the current element to the right
                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = temp; // Insert the current element at its correct position
            }
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the ShellSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// ShellSort is an in-place comparison-based sorting algorithm that builds upon the InsertionSort algorithm.
        /// It starts by sorting pairs of elements that are far apart, and progressively reduces the gap between elements
        /// to be compared until the gap becomes 1, at which point the algorithm performs a final InsertionSort.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log n) - ShellSort has an average-case time complexity of O(n log n) for most inputs.
        /// - Worst Case: O(n^2) - In the worst-case scenario, the time complexity is O(n^2), but it depends on the chosen gap sequence.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - ShellSort operates directly on the input array and does not require additional space
        /// beyond a few variables to store temporary values and loop indices. The space complexity is constant.
        /// </para>
        /// </remarks>
        public static void ShellSort(int[] arr)
        {
            int n = arr.Length; // Get the length of the array
            int gap = n / 2; // Set the initial gap value

            // Perform Shell Sort with decreasing gap values
            while (gap > 0)
            {
                // Iterate over each subarray with the current gap
                for (int i = gap; i < n; i++)
                {
                    // Store the current element in a temporary variable
                    int temp = arr[i];
                    int j = i;

                    // Shift elements in the subarray to create the correct position for the current element
                    while (j >= gap && arr[j - gap] > temp)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }
                    arr[j] = temp; // Insert the current element at its correct position
                }
                gap /= 2; // Reduce the gap value
            }
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the SplaySort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// SplaySort is a sorting algorithm that utilizes a self-adjusting binary search tree called a Splay tree.
        /// It repeatedly inserts each element from the input array into the Splay tree and performs splaying operations
        /// to bring the recently accessed elements closer to the root of the tree. Finally, an in-order traversal of
        /// the Splay tree retrieves the elements in sorted order and updates the input array accordingly.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log n) - SplaySort has an average-case time complexity of O(n log n) for most inputs.
        /// - Worst Case: O(n^2) - In the worst-case scenario, the time complexity is O(n^2), but it depends on the input order
        /// and the specific implementation of the Splay tree.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(n) - SplaySort requires additional space to store the Splay tree, which has a space
        /// complexity of O(n) proportional to the number of elements in the input array. The input array is modified in-place.
        /// </para>
        /// </remarks>
        public static void SplaySort(int[] arr)
        {
            SplayTree tree = new SplayTree(); // Create a new SplayTree
            Node? root = null; // Initialize the root of the tree as null

            // Insert each element from the array into the SplayTree
            for (int i = 0; i < arr.Length; i++)
            {
                root = tree.Insert(root, arr[i]); // Insert the current element into the tree and update the root
            }
            int index = 0; // Initialize an index to keep track of the position in the array

            // Perform an in-order traversal of the tree and update the array with sorted elements
            tree.InOrderTraversal(root, (key) =>
            {
                arr[index++] = key; // Update the current position in the array with the traversed key
            });
        }
    }
}
