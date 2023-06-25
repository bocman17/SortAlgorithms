namespace SortAlgorithmsLibrary
{
    public class SortAlgorithms
    {
        public static void Swap(int[] arr, int i, int j)
        {
            //int temp = arr[i];
            //arr[i] = arr[j];
            //arr[j] = temp;
            (arr[j], arr[i]) = (arr[i], arr[j]);
        }

        public static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;

                    // Swap elements if they are less than or equal to the pivot
                    Swap(arr, i, j);
                }
            }
            // Move the pivot to its correct position
            Swap(arr, i + 1, right);

            return i + 1;
        }
    }
}
