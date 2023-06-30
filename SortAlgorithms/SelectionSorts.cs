using SortAlgorithms.HelperClasses;
using System;

namespace SortAlgorithmsLibrary
{
    public class SelectionSorts : SortAlgorithms
    {
        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                int minIndex = i;
                for (int j = i; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Swap(arr, i, minIndex);
                }
            }
        }

        public static void HeapSort(int[] arr)
        {
            int n = arr.Length;

            // build Max Heap
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            for (int i = n - 1; i > 0; i--)
            {
                Swap(arr, 0, i);
                Heapify(arr, i, 0);
            }
        }

        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(arr, i, largest);
                Heapify(arr, n, largest);
            }
        }

        public static void SmoothSort(int[] arr)
        {
            int n = arr.Length;

            int p = n - 1;
            int q = p;
            int r = 0;

            // Build the Leonardo heap by merging
            // pairs of adjacent trees
            while (p > 0)
            {
                if ((r & 0x03) == 0)
                {
                    HeapifyLeonardo(arr, r, q);
                }

                if (Leonardo(r) == p)
                {
                    r++;
                }
                else
                {
                    r--;
                    q -= Leonardo(r);
                    HeapifyLeonardo(arr, r, q);
                    q = r - 1;
                    r++;
                }
                Swap(arr, 0, p);
                p--;
            }

            // Convert the Leonardo heap
            // back into an array
            for (int i = 0; i < n - 1; i++)
            {
                int j = i + 1;
                while (j > 0 && arr[j] < arr[j - 1])
                {
                    Swap(arr, j, j - 1);
                    j--;
                }
            }
        }

        private static void HeapifyLeonardo(int[] arr, int start, int end)
        {
            int i = start;
            int j = 0;
            int k = 0;

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
                    Swap(arr, l, l - i);
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
            return Leonardo(k - 1) + Leonardo(k - 2) + 1;
        }

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

        public static void TournamentSort(int[] arr)
        {
            int n = arr.Length;
            if(n < 2)
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


        public static void CycleSort(int[] arr)
        {
            int n = arr.Length;
            int start, element, pos, temp, i;

            /*Loop to traverse the array elements and place them on the correct position*/
            for (start = 0; start < n - 2; start++)
            {
                element = arr[start];

                /*position to place the element*/
                pos = start;

                for (i = start + 1; i < n; i++)
                {
                    if (arr[i] < element)
                    {
                        pos++;
                    }
                }

                if (pos == start) /*if the element is at exact position*/
                {
                    continue;
                }

                while (element == arr[pos])
                {
                    pos++;
                }

                if (pos != start) /*put element at its exact position*/
                {
                    //swap(element, a[pos]);    
                    temp = element;
                    element = arr[pos];
                    arr[pos] = temp;
                }

                /*Rotate rest of the elements*/
                while (pos != start)
                {
                    pos = start;

                    /*find position to put the element*/
                    for (i = start + 1; i < n; i++)
                    {
                        if (arr[i] < element)
                        {
                            pos++;
                        }
                    }

                    /*Ignore duplicate elements*/
                    while (element == arr[pos])
                    {
                        pos++;
                    }

                    /*put element to its correct position*/
                    if (element != pos)
                    {
                        temp = element;
                        element = arr[pos];
                        arr[pos] = temp;
                    }
                }
            }
        }


    }
}
