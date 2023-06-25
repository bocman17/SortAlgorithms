namespace SortAlgorithmsLibrary
{
    public class OtherSorts : SortAlgorithms
    {
        public static void PancakeSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = n - 1; i > 0; i--)
            {
                int maxIndex = FindMaxIndex(arr, i);

                if (maxIndex != i)
                {
                    Flip(arr, maxIndex);
                    Flip(arr, i);
                }
            }
        }

        private static void Flip(int[] arr, int index)
        {
            int start = 0;
            while (start < index)
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
