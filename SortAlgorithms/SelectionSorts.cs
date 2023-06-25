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

        public static void SmoothSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                SmoothDown(arr, i);
            }

            for (int size = n - 1; size > 1; size--)
            {
                Swap(arr, 0, size);
                SmoothUp(arr, 0, size - 1);
            }
        }

        private static void SmoothUp(int[] arr, int start, int end)
        {
            int i = end;
            while (i > start)
            {
                int j = i - 1;
                while (j >= start && arr[j] > arr[i])
                {
                    j--;
                }
                Rotate(arr, j + 1, i + 1);
                i = j;
            }
        }

        private static void Rotate(int[] arr, int start, int end)
        {
            int temp = arr[end];
            while (end > start)
            {
                arr[end] = arr[end - 1];
                end--;
            }
            arr[start] = temp;
        }

        private static void SmoothDown(int[] arr, int i)
        {
            while (i > 0 && arr[i - 1] > arr[i])
            {
                Swap(arr, i, i - 1);
                i--;
            }
        }
    }
}
