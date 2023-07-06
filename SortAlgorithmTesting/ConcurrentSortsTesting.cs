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
        [TestCase(4096)]
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
    }
}
