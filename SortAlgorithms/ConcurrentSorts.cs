using System.Collections.Concurrent;

namespace SortAlgorithmsLibrary
{
    public class ConcurrentSorts : SortAlgorithms
    {
        public static void BitonicMergeSort(int[] array)
        {
            BitonicSort(array, 0, array.Length, true);
        }

        private static void BitonicSort(int[] array, int low, int count, bool ascending)
        {
            if (count <= 1)
                return;

            int mid = count / 2;

            Parallel.Invoke(
                () => BitonicSort(array, low, mid, !ascending),
                () => BitonicSort(array, low + mid, count - mid, ascending)
            );

            BitonicMerge(array, low, count, ascending);
        }

        private static void BitonicMerge(int[] array, int low, int count, bool ascending)
        {
            if (count <= 1)
                return;

            int k = GreatestPowerOfTwoLessThan(count);

            Parallel.For(low, low + count - k, i =>
            {
                if ((array[i] > array[i + k] && ascending) || (array[i] < array[i + k] && !ascending))
                {
                    Swap(array, i, i + k);
                }
            });

            BitonicMerge(array, low, k, ascending);
            BitonicMerge(array, low + k, count - k, ascending);
        }

        private static int GreatestPowerOfTwoLessThan(int n)
        {
            int k = 1;
            while (k < n)
            {
                k <<= 1;
            }
            return k >> 1;
        }

        public static void BatcherOddEvenMergeSort(int[] array)
        {
            int n = array.Length;
            OddEvenMergeSort(array, 0, n - 1);
        }

        private static void OddEvenMergeSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;

                Parallel.Invoke(
                    () => OddEvenMergeSort(array, low, mid),
                    () => OddEvenMergeSort(array, mid + 1, high)
                );

                OddEvenMerge(array, low, high);
            }
        }

        private static void OddEvenMerge(int[] array, int low, int high)
        {
            if (high > low)
            {
                int mid = low + (high - low) / 2;

                Parallel.Invoke(
                    () => Merge(array, low, mid),
                    () => Merge(array, mid + 1, high)
                );

                Merge(array, low, high);
            }
        }

        private static void Merge(int[] array, int low, int high)
        {
            int mid = low + (high - low) / 2;
            int n = high - low + 1;
            int[] temp = new int[n];
            int i = low;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= high)
            {
                if (array[i] <= array[j])
                {
                    temp[k++] = array[i++];
                }
                else
                {
                    temp[k++] = array[j++];
                }
            }

            while (i <= mid)
            {
                temp[k++] = array[i++];
            }

            while (j <= high)
            {
                temp[k++] = array[j++];
            }

            Array.Copy(temp, 0, array, low, n);
        }

        public static void PairwiseSortingNetworkSort(int[] array)
        {
            int n = array.Length;
            SortPairwise(array, 0, n - 1);
        }

        private static void SortPairwise(int[] array, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;

                Parallel.Invoke(
                    () => SortPairwise(array, low, mid),
                    () => SortPairwise(array, mid + 1, high)
                );

                MergePairwise(array, low, high);
            }
        }

        private static void MergePairwise(int[] array, int low, int high)
        {
            int length = high - low + 1;

            for (int step = 1; step < length; step *= 2)
            {
                Parallel.For(low, high - step + 1, i =>
                {
                    if (i % (2 * step) == low % (2 * step))
                    {
                        int mid = i + step - 1;
                        int end = Math.Min(i + 2 * step - 1, high);

                        MergeSubArrays(array, i, mid, end);
                    }
                });
            }
        }

        private static void MergeSubArrays(int[] array, int low, int mid, int high)
        {
            int[] temp = new int[high - low + 1];

            int i = low;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= high)
            {
                if (array[i] <= array[j])
                {
                    temp[k] = array[i];
                    i++;
                }
                else
                {
                    temp[k] = array[j];
                    j++;
                }
                k++;
            }

            while (i <= mid)
            {
                temp[k] = array[i];
                i++;
                k++;
            }

            while (j <= high)
            {
                temp[k] = array[j];
                j++;
                k++;
            }

            for (int x = 0; x < temp.Length; x++)
            {
                array[low + x] = temp[x];
            }
        }



        public static void SampleSort(int[] array)
        {
            int threshold = Environment.ProcessorCount;
            int left = 0;
            int right = array.Length - 1;
            var stack = new ConcurrentStack<(int, int)>();
            stack.Push((left, right));

            (int, int) currentRange;
            while (stack.TryPop(out currentRange))
            {
                (left, right) = currentRange;

                if (right - left < threshold)
                {
                    SmallSort(array, left, right);
                }
                else
                {
                    int p = Environment.ProcessorCount;
                    int[] splitters = new int[p - 1];
                    SelectSplitters(array, left, right, splitters);

                    int[] bucketSizes = new int[p];
                    int[] bucketIndexes = new int[p];
                    PartitionElements(array, left, right, splitters, bucketSizes, bucketIndexes);

                    Parallel.For(0, p, i =>
                    {
                        int bucketLeft = bucketIndexes[i];
                        int bucketRight = (i < p - 1) ? bucketIndexes[i + 1] - 1 : right;
                        stack.Push((bucketLeft, bucketRight));
                    });
                }
            }
        }

        private static void SmallSort(int[] array, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= left && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }

        private static void SelectSplitters(int[] array, int left, int right, int[] splitters)
        {
            Random random = new Random();
            int interval = (right - left + 1) / splitters.Length;
            for (int i = 0; i < splitters.Length; i++)
            {
                int index = random.Next(left + interval * i, left + interval * (i + 1));
                splitters[i] = array[index];
            }
            SmallSort(splitters, 0, splitters.Length - 1);
        }

        private static void PartitionElements(int[] array, int left, int right, int[] splitters, int[] bucketSizes, int[] bucketIndexes)
        {
            Array.Fill(bucketSizes, 0);

            for (int i = left; i <= right; i++)
            {
                int bucket = GetBucket(array[i], splitters);
                bucketSizes[bucket]++;
            }

            bucketIndexes[0] = left;
            for (int i = 1; i < bucketIndexes.Length; i++)
            {
                bucketIndexes[i] = bucketIndexes[i - 1] + bucketSizes[i - 1];
            }

            int[] bucketCurrentIndexes = new int[bucketIndexes.Length];
            Array.Copy(bucketIndexes, bucketCurrentIndexes, bucketIndexes.Length);

            int[] tempArray = new int[right - left + 1]; // Temporary array to hold elements

            for (int i = left; i <= right; i++)
            {
                int bucket = GetBucket(array[i], splitters);
                int index = bucketCurrentIndexes[bucket] - left; // Adjust index relative to the left
                tempArray[index] = array[i];
                bucketCurrentIndexes[bucket]++;
            }

            // Copy the elements from the temporary array back to the original array
            Array.Copy(tempArray, 0, array, left, tempArray.Length);
        }


        private static int GetBucket(int value, int[] splitters)
        {
            int left = 0;
            int right = splitters.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (value <= splitters[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return left;
        }
    }
}
