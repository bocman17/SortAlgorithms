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
    }
}
