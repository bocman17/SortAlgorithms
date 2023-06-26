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
