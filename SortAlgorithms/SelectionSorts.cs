using SortAlgorithms.HelperClasses;
using System;

namespace SortAlgorithmsLibrary
{
    public class SelectionSorts : SortAlgorithms
    {
        /// <summary>
        /// Sorts an array of integers in ascending order using the SelectionSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// SelectionSort is a simple comparison-based sorting algorithm that works by repeatedly selecting the smallest
        /// element from the unsorted portion of the array and placing it at the beginning. It involves two main operations:
        /// finding the index of the minimum element and swapping it with the current position. By iteratively performing
        /// these operations, the array is sorted in ascending order.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n^2) - SelectionSort has an average-case time complexity of O(n^2) for most inputs.
        /// - Worst Case: O(n^2) - In the worst-case scenario, the time complexity is O(n^2) when the array is in reverse order.
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - SelectionSort operates in-place, modifying the input array directly. It does not require
        /// additional space proportional to the input size.
        /// </para>
        /// </remarks>
        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                int minIndex = i;

                // Find the index of the minimum element in the unsorted portion
                for (int j = i; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // If the minimum element is not already at the current position, swap the elements
                if (minIndex != i)
                {
                    Swap(arr, i, minIndex);
                }
            }
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the HeapSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// HeapSort is an efficient comparison-based sorting algorithm that utilizes the concept of a binary heap. It works
        /// by first building a Max Heap from the input array, where the largest element is at the root. Then, it repeatedly
        /// removes the root element (which is the maximum) and places it at the end of the array, effectively building a
        /// sorted section from the end. This process is repeated until the entire array is sorted in ascending order.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log n) - HeapSort has an average-case time complexity of O(n log n) for most inputs.
        /// - Worst Case: O(n log n) - In the worst-case scenario, the time complexity is O(n log n).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - HeapSort operates in-place, modifying the input array directly. It does not require
        /// additional space proportional to the input size.
        /// </para>
        /// </remarks>
        public static void HeapSort(int[] arr)
        {
            int n = arr.Length;

            // build Max Heap
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // Heap Sort
            for (int i = n - 1; i > 0; i--)
            {
                Swap(arr, 0, i); // Swap the root (maximum element) with the last element
                Heapify(arr, i, 0); // Heapify the reduced heap
            }
        }

        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // Find the largest element among the root, left child, and right child
            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            // If the largest element is not the root, swap them and continue heapifying
            if (largest != i)
            {
                Swap(arr, i, largest);
                Heapify(arr, n, largest);
            }
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the SmoothSort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// SmoothSort is a sorting algorithm that is based on Leonardo numbers and uses a combination of heap-based
        /// and insertion-based techniques. It aims to provide a balance between performance and simplicity. SmoothSort
        /// begins by building a Leonardo heap, which is a binary heap variant that allows for efficient sorting. It then
        /// converts the Leonardo heap back into an array by repeatedly extracting the minimum element and inserting it
        /// in its correct position. The algorithm has a unique approach for heapifying and building the Leonardo heap.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log n) - SmoothSort has an average-case time complexity of O(n log n) for most inputs.
        /// - Worst Case: O(n log n) - In the worst-case scenario, the time complexity is O(n log n).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - SmoothSort operates in-place, modifying the input array directly. It does not require
        /// additional space proportional to the input size.
        /// </para>
        /// </remarks>
        public static void SmoothSort(int[] arr)
        {
            int n = arr.Length;

            int p = n - 1;
            int q = p;
            int r = 0;

            // Build the Leonardo heap by merging pairs of adjacent trees
            while (p > 0)
            {
                if ((r & 0x03) == 0)
                {
                    HeapifyLeonardo(arr, r, q); // Heapify the Leonardo tree at index r using the value of q
                }

                if (Leonardo(r) == p)
                {
                    r++;
                }
                else
                {
                    r--;
                    q -= Leonardo(r);
                    HeapifyLeonardo(arr, r, q); // Heapify the Leonardo tree at index r using the value of q
                    q = r - 1;
                    r++;
                }
                Swap(arr, 0, p); // Swap the root element (maximum value) with the element at index p
                p--;
            }

            // Convert the Leonardo heap back into an array by performing insertion sort
            for (int i = 0; i < n - 1; i++)
            {
                int j = i + 1;
                while (j > 0 && arr[j] < arr[j - 1])
                {
                    Swap(arr, j, j - 1); // Swap elements until the array is sorted
                    j--;
                }
            }
        }

        private static void HeapifyLeonardo(int[] arr, int start, int end)
        {
            int i = start;
            int j = 0;
            int k = 0;

            // Build the Leonardo heap by heapifying
            while (k < end - start + 1)
            {
                if ((k & 0xAAAAAAAA) == 0xAAAAAAAA)
                {
                    j += i;
                    i >>= 1;
                }
                else
                {
                    i += j;
                    j >>= 1;
                }
                k++;
            }

            // Heapify the Leonardo heap
            while (i > 0)
            {
                j >>= 1;
                int l = i + j;
                while (l < end)
                {
                    if (arr[l] > arr[l - i])
                    {
                        break;
                    }
                    Swap(arr, l, l - i); // Swap elements until the heap property is satisfied
                    l += i;
                }
                i = j;
            }
        }

        private static int Leonardo(int k)
        {
            if (k < 2)
            {
                return 1;
            }
            return Leonardo(k - 1) + Leonardo(k - 2) + 1; // Calculate the k-th Leonardo number recursively
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the Cartesian Tree Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Cartesian Tree Sort is an algorithm that uses the properties of Cartesian trees to sort the given array efficiently.
        /// It first constructs a Cartesian tree from the elements of the array. The Cartesian tree is a binary tree where each
        /// node has a value and a priority, and it satisfies the Cartesian tree property: for any node, its value is greater
        /// than all the values in its left subtree and less than all the values in its right subtree. The algorithm then performs
        /// a priority queue-based traversal of the Cartesian tree to extract the elements in sorted order and update the array.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log n) - The average-case time complexity of Cartesian Tree Sort is O(n log n).
        /// - Worst Case: O(n^2) - In the worst-case scenario, when the input array is already sorted in descending order,
        ///   the time complexity of Cartesian Tree Sort becomes O(n^2).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(n) - Cartesian Tree Sort requires additional space for constructing the Cartesian tree.
        /// The space complexity is O(n) for the temporary arrays used during the construction of the tree.
        /// </para>
        /// </remarks>
        public static void CartesianTreeSort(int[] arr)
        {
            if (arr.Length < 2)
            {
                return;
            }
            Node? root = BuildCartesianTree(arr, arr.Length);
            PQBasedTraversal(root, arr);
        }

        // This function sorts by pushing and popping the Cartesian Tree nodes in a pre-order like fashion
        private static void PQBasedTraversal(Node? root, int[] arr)
        {
            // We will use a priority queue to sort the partially-sorted data efficiently.
            // Unlike Heap, Cartesian tree makes use of the fact that the data is partially sorted
            PriorityQueue<IntNodePair> priorityQueue = new PriorityQueue<IntNodePair>();
            if (root is not null)
            {
                priorityQueue.Enqueue(new IntNodePair(root.Value, root));
            }
            int i = 0;

            // Resembles a pre-order traversal as first data is printed then the left and then right child
            while (!priorityQueue.IsEmpty())
            {
                IntNodePair poppedPair = priorityQueue.Dequeu();
                arr[i++] = poppedPair.first;


                if (poppedPair.second is not null && poppedPair.second.Left is not null)
                {
                    priorityQueue.Enqueue(new IntNodePair(poppedPair.second.Left.Value, poppedPair.second.Left));
                }

                if (poppedPair.second is not null && poppedPair.second.Right is not null)
                {
                    priorityQueue.Enqueue(new IntNodePair(poppedPair.second.Right.Value, poppedPair.second.Right));
                }
            }
        }

        private static Node? BuildCartesianTreeUtil(
            int root, int[] arr, int[] parent, int[] leftChild, int[] rightChild)
        {
            if (root == -1)
            {
                return null;
            }

            Node temp = new Node(arr[root]);
            temp.Left = BuildCartesianTreeUtil(leftChild[root], arr, parent, leftChild, rightChild);
            temp.Right = BuildCartesianTreeUtil(rightChild[root], arr, parent, leftChild, rightChild);
            return temp;
        }

        // A function to create the Cartesian Tree in O(N) time
        private static Node? BuildCartesianTree(int[] arr, int n)
        {
            // Arrays to hold the index of parent, left-child, right-child of each number in the input array
            int[] parent = new int[n];
            int[] leftChild = new int[n];
            int[] rightChild = new int[n];

            // Initialize all array values as -1
            Array.Fill(parent, -1);
            Array.Fill(leftChild, -1);
            Array.Fill(rightChild, -1);

            // 'root' and 'last' store the index of the root and the last processed element of the Cartesian Tree.
            // Initially, we take the root of the Cartesian Tree as the first element of the input array.
            // This can change according to the algorithm
            int root = 0, last;

            // Starting from the second element of the input array to the last,
            // scan across the elements, adding them one at a time
            for (int i = 1; i < n; i++)
            {
                last = i - 1;
                rightChild[i] = -1;

                // Scan upward from the node's parent up to the root of the tree until a node is found
                // whose value is smaller than the current one.
                // This is the same as Step 2 mentioned in the algorithm
                while (arr[last] >= arr[i] && last != root)
                {
                    last = parent[last];
                }

                // arr[i] is the smallest element yet; make it the new root
                if (arr[last] >= arr[i])
                {
                    parent[root] = i;
                    leftChild[i] = root;
                    root = i;
                }
                else if (rightChild[last] == -1)
                {
                    rightChild[last] = i;
                    parent[i] = last;
                    leftChild[i] = -1;
                }
                else
                {
                    parent[rightChild[last]] = i;
                    leftChild[i] = rightChild[last];
                    rightChild[last] = i;
                    parent[i] = last;
                }
            }

            // Since the root of the Cartesian Tree has no parent, we assign it -1
            parent[root] = -1;
            return BuildCartesianTreeUtil(root, arr, parent, leftChild, rightChild);
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the Tournament Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Tournament Sort is an algorithm that uses the concept of tournaments to sort the given array. It works by dividing
        /// the array into multiple runs and then merging these runs until a single sorted run is obtained.
        /// </para>
        /// <para>
        /// The algorithm begins by creating a priority queue (min-heap) and adding elements from the array to the queue.
        /// When the number of elements in the queue reaches a certain threshold (equal to the length of the input array),
        /// a run is extracted from the queue and added to a list of runs. This process continues until all elements are
        /// processed, resulting in multiple runs.
        /// </para>
        /// <para>
        /// The runs are then merged iteratively until a single sorted run is obtained. This is achieved by merging pairs
        /// of runs at each iteration until only one run remains.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log n) - The average-case time complexity of Tournament Sort is O(n log n).
        /// - Worst Case: O(n log n) - The worst-case time complexity of Tournament Sort is O(n log n).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(n) - Tournament Sort requires additional space for storing the runs and the merged runs.
        /// The space complexity is O(n) for the temporary arrays used during the sorting process.
        /// </para>
        /// </remarks>
        public static void TournamentSort(int[] arr)
        {
            int n = arr.Length;
            if (n < 2)
            {
                return;
            }
            List<int[]> runs = new List<int[]>(); // List to store the runs
            PriorityQueue<int> queue = new PriorityQueue<int>(n); // Priority queue to create the min-heap

            foreach (int num in arr)
            {
                queue.EnqueueMinHeap(num); // Add elements to the min-heap

                if (queue.MinHeapCount == n)
                {
                    int[] run = ExtractRunFromQueue(queue); // Extract a run from the min-heap
                    runs.Add(run); // Add the run to the list of runs
                }
            }

            while (queue.MinHeapCount > 0)
            {
                int[] run = ExtractRunFromQueue(queue); // Extract the remaining run from the min-heap
                runs.Add(run); // Add the run to the list of runs
            }

            MergeRuns(runs, arr); // Merge the runs and store the sorted result back in the original array
        }

        private static int[] ExtractRunFromQueue(PriorityQueue<int> queue)
        {
            int[] run = new int[queue.MinHeapCount]; // Create an array to store the run

            for (int i = 0; i < run.Length; i++)
            {
                run[i] = queue.DequeueMinHeap(); // Extract elements from the min-heap and store them in the run array
            }

            return run; // Return the extracted run
        }

        private static void MergeRuns(List<int[]> runs, int[] arr)
        {
            while (runs.Count > 1)
            {
                List<int[]> mergedRuns = new List<int[]>(); // List to store the merged runs

                for (int i = 0; i < runs.Count; i += 2)
                {
                    if (i + 1 < runs.Count)
                    {
                        int[] merged = MergeTwoRuns(runs[i], runs[i + 1]); // Merge two runs
                        mergedRuns.Add(merged); // Add the merged run to the list of merged runs
                    }
                    else
                    {
                        mergedRuns.Add(runs[i]); // Add the last run (unmerged) to the list of merged runs
                    }
                }

                runs = mergedRuns; // Replace the list of runs with the list of merged runs
            }

            Array.Copy(runs[0], 0, arr, 0, arr.Length); // Copy the elements of the final run to the original array
        }

        private static int[] MergeTwoRuns(int[] run1, int[] run2)
        {
            int[] merged = new int[run1.Length + run2.Length]; // Create an array to store the merged run
            int i = 0, j = 0, k = 0;

            while (i < run1.Length && j < run2.Length)
            {
                if (run1[i] <= run2[j])
                    merged[k++] = run1[i++]; // Add the smaller element from run1 to the merged run
                else
                    merged[k++] = run2[j++]; // Add the smaller element from run2 to the merged run
            }

            while (i < run1.Length)
                merged[k++] = run1[i++]; // Add any remaining elements from run1 to the merged run

            while (j < run2.Length)
                merged[k++] = run2[j++]; // Add any remaining elements from run2 to the merged run

            return merged; // Return the merged run
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the Cycle Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Cycle Sort is an in-place comparison-based sorting algorithm that minimizes the number of writes to memory.
        /// It works by dividing the array into cycles and placing each element on its correct position within the cycle.
        /// The algorithm performs a series of swaps to move each element to its appropriate place until the array is sorted.
        /// </para>
        /// <para>
        /// The algorithm starts by iterating over the array, considering each element as the starting element of a cycle.
        /// It finds the correct position of the element within its cycle by counting the number of elements that are smaller.
        /// If the element is already at its correct position, it proceeds to the next element.
        /// Otherwise, it swaps the element with the element currently at the desired position, continuing the process until
        /// the element is in its correct position within the cycle.
        /// </para>
        /// <para>
        /// After placing an element in its correct position within the cycle, the algorithm performs a series of additional
        /// swaps to rotate the remaining elements in the cycle until the original starting element is reached again.
        /// This process continues until all cycles are completed and the array is fully sorted.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n^2) - The average-case time complexity of Cycle Sort is O(n^2).
        /// - Worst Case: O(n^2) - The worst-case time complexity of Cycle Sort is O(n^2).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - Cycle Sort is an in-place sorting algorithm, meaning it operates directly on the
        /// input array and does not require additional space proportional to the input size.
        /// </para>
        /// </remarks>
        public static void CycleSort(int[] arr)
        {
            int n = arr.Length;
            int start, element, pos, temp, i;

            // Loop to traverse the array elements and place them on the correct position
            for (start = 0; start < n - 2; start++)
            {
                element = arr[start];

                // position to place the element
                pos = start;

                for (i = start + 1; i < n; i++)
                {
                    if (arr[i] < element)
                    {
                        pos++;
                    }
                }

                if (pos == start) // if the element is at exact position
                {
                    continue;
                }

                while (element == arr[pos])
                {
                    pos++;
                }

                if (pos != start) // put element at its exact position
                {
                    //swap(element, a[pos]);    
                    temp = element;
                    element = arr[pos];
                    arr[pos] = temp;
                }

                // Rotate rest of the elements
                while (pos != start)
                {
                    pos = start;

                    // find position to put the element
                    for (i = start + 1; i < n; i++)
                    {
                        if (arr[i] < element)
                        {
                            pos++;
                        }
                    }

                    // Ignore duplicate elements
                    while (element == arr[pos])
                    {
                        pos++;
                    }

                    // put element to its correct position
                    if (element != pos)
                    {
                        temp = element;
                        element = arr[pos];
                        arr[pos] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the Weak Heap Sort algorithm.
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        /// <remarks>
        /// <para>
        /// Weak Heap Sort is an in-place comparison-based sorting algorithm that utilizes the concept of a weak heap,
        /// a binary tree structure that satisfies the weak heap property, to perform the sorting operation.
        /// </para>
        /// <para>
        /// The algorithm consists of two main steps: building the weak heap and sorting the array.
        /// In the first step, the algorithm builds the weak heap by iteratively sifting down each internal node in the tree
        /// starting from the last internal node up to the root. This step ensures that the weak heap property is satisfied,
        /// where each node's value is greater than or equal to the values of its children.
        /// </para>
        /// <para>
        /// In the second step, the algorithm sorts the array by repeatedly exchanging the root (the maximum element in the heap)
        /// with the last element of the array and then sifting down the new root to maintain the weak heap property.
        /// This process continues until all elements are placed in their correct positions, resulting in a sorted array.
        /// </para>
        /// <para>
        /// <b>Time Complexity:</b>
        /// - Average Case: O(n log n) - The average-case time complexity of Weak Heap Sort is O(n log n).
        /// - Worst Case: O(n log n) - The worst-case time complexity of Weak Heap Sort is O(n log n).
        /// </para>
        /// <para>
        /// <b>Space Complexity:</b> O(1) - Weak Heap Sort is an in-place sorting algorithm, meaning it operates directly on the
        /// input array and does not require additional space proportional to the input size.
        /// </para>
        /// </remarks>
        public static void WeakHeapSort(int[] arr)
        {
            int n = arr.Length;
            if (n < 2)
            {
                return;
            }

            // Build the weak heap
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                SiftDown(arr, i, n);
            }

            // Sort the array by repeatedly exchanging the root with the last element and sifting down
            for (int i = n - 1; i > 0; i--)
            {
                Swap(arr, 0, i); // Swap the root with the last element
                SiftDown(arr, 0, i); // Sift down to maintain the weak heap property
            }
        }

        private static void SiftDown(int[] arr, int root, int n)
        {
            int j = root;
            int lastChild = n / 2 - 1; // Find the last child (height 1) of the root

            while (j <= lastChild)
            {
                int leftChild = 2 * j + 1; // Left child index
                int rightChild = 2 * j + 2; // Right child index
                int targetChild;

                if (rightChild < n && arr[rightChild] > arr[leftChild]) // Modified condition for ascending order
                {
                    targetChild = rightChild; // Choose the larger child
                }
                else
                {
                    targetChild = leftChild;
                }

                if (arr[targetChild] > arr[j]) // Modified comparison for ascending order
                {
                    Swap(arr, j, targetChild); // Swap the target child with the root
                    j = targetChild; // Move to the child for the next iteration
                }
                else
                {
                    break; // Break if the weak heap property is satisfied
                }
            }
        }
    }
}
