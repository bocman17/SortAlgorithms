namespace SortAlgorithmsLibrary
{
    public partial class SortAlgorithms
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

        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                int temp = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = temp;
            }
        }

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

        public static void Swap(int[] arr, int i, int j)
        {
            //int temp = arr[i];
            //arr[i] = arr[j];
            //arr[j] = temp;
            (arr[j], arr[i]) = (arr[i], arr[j]);
        }
    }
}