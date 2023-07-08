namespace SortAlgorithmTesting
{
    [TestFixture]
    public class ConcurrentSortsTesting
    {
        [Test]
        public void BitonicMergeSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ConcurrentSorts.BitonicMergeSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void BitonicMergeSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply BitonicMerge Sort algorithm to the array
            ConcurrentSorts.BitonicMergeSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void BatcherOddEvenMergeSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ConcurrentSorts.BatcherOddEvenMergeSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void BatcherOddEvenMergeSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply BatcherOddEvenMerge Sort algorithm to the array
            ConcurrentSorts.BatcherOddEvenMergeSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void PairwiseSortingNetworkSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ConcurrentSorts.PairwiseSortingNetworkSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void PairwiseSortingNetworkSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply PairwiseSortingNetwork Sort algorithm to the array
            ConcurrentSorts.PairwiseSortingNetworkSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void SampleSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ConcurrentSorts.SampleSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void SampleSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Sample Sort algorithm to the array
            ConcurrentSorts.SampleSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }
    }
}
