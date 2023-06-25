namespace SortAlgorithmsLibrary
{
    public class MergeSorts : SortAlgorithms
    {
        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return;
            }

            int middle = arr.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[arr.Length - middle];

            Array.Copy(arr, 0, left, 0, middle);
            Array.Copy(arr, middle, right, 0, arr.Length - middle);

            MergeSort(left);
            MergeSort(right);

            Merge(arr, left, right);
        }

        private static void Merge(int[] mergedArr, int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    mergedArr[mergedIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergedArr[mergedIndex] = right[rightIndex];
                    rightIndex++;
                }

                mergedIndex++;
            }

            while (leftIndex < left.Length)
            {
                mergedArr[mergedIndex] = left[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            while (rightIndex < right.Length)
            {
                mergedArr[mergedIndex] = right[rightIndex];
                rightIndex++;
                mergedIndex++;
            }
        }
    }
}
