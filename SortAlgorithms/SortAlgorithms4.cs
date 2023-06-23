namespace SortAlgorithmsLibrary
{
    public partial class SortAlgorithms
    {
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

        public static void BogoSort(int[] arr)
        {
            Random random = new Random();
            while (!IsSorted(arr))
            {
                Shuffle(arr, random);
            }
        }

        private static void Shuffle(int[] arr, Random random)
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Swap(arr, i, j);
            }
        }

        private static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static void PancakeSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = n - 1; i > 0; i--)
            {
                int maxIndex = FindMaxIndex(arr, i);

                if(maxIndex != i)
                {
                    Flip(arr, maxIndex);
                    Flip(arr, i);
                }
            }
        }

        private static void Flip(int[] arr, int index)
        {
            int start = 0;
            while(start < index)
            {
                //int temp = arr[start];
                //arr[start] = arr[index];
                //arr[index] = temp;
                (arr[index], arr[start]) = (arr[start], arr[index]);
                start++;
                index--;
            }
        }

        private static int FindMaxIndex(int[] arr, int end)
        {
            int maxIndex = 0;

            for (int i = 1; i <= end; i++)
            {
                if (arr[i] > arr[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}
