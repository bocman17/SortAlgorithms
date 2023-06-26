namespace SortAlgorithmsLibrary
{
    public class ImpracticalSorts : SortAlgorithms
    {
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

        public static void StoogeSort(int[] arr)
        {
            if(arr.Length < 2)
            {
                return;
            }
            StoogeSort(arr, 0, arr.Length - 1);
        }

        private static void StoogeSort(int[] arr, int start, int end)
        {
            if (arr[start] > arr[end])
            {
                Swap(arr, start, end);
            }

            if (end - start + 1 > 2)
            {
                int third = (end - start + 1) / 3;

                StoogeSort(arr, start, end - third);
                StoogeSort(arr, start + third, end);
                StoogeSort(arr, start, end - third);
            }
        }

        public static void SlowSort(int[] arr)
        {
            SlowSort(arr, 0, arr.Length - 1);
        }

        private static void SlowSort(int[] arr, int start, int end)
        {
            if(start >= end)
            {
                return;
            }

            int mid = (start + end) / 2;

            SlowSort(arr, start, mid);
            SlowSort(arr, mid + 1, end);

            if (arr[mid] > arr[end])
            {
                Swap(arr, mid, end);
            }

            SlowSort(arr, start, end - 1);
        }
    }
}
