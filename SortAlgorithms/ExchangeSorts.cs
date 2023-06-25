namespace SortAlgorithmsLibrary

{
    public class ExchangeSorts : SortAlgorithms
    {
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length - 1;
            bool swapped;

            for (int i = 0; i < n; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }

        public static void CoctailShakeSort(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            bool swapped;
            while (left < right)
            {
                swapped = false;
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }

                right--;

                for (int i = right; i > left; i--)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        Swap(arr, i, i - 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }

                left++;
            }
        }

        public static void CombSort(int[] arr)
        {
            int n = arr.Length;
            int gap = n;
            bool swapped = true;

            while (gap > 1 || swapped)
            {
                gap = GetNextGap(gap);
                swapped = false;

                for (int i = 0; i < n - gap; i++)
                {
                    if (arr[i] > arr[i + gap])
                    {
                        Swap(arr, i, i + gap);
                        swapped = true;
                    }
                }
            }
        }

        private static int GetNextGap(int gap)
        {
            gap = (gap * 10) / 13;
            return Math.Max(1, gap);
        }

        public static void GnomeSort(int[] arr)
        {
            int n = arr.Length;
            int i = 1;
            while (i < n)
            {
                if (arr[i] >= arr[i - 1])
                {
                    i++;
                }
                else
                {
                    Swap(arr, i, i - 1);
                    if (i > 1)
                    {
                        i--;
                    }
                }
            }
        }

        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                QuickSort(arr, left, pivot - 1);
                QuickSort(arr, pivot + 1, right);
            }
        }
    }
}
