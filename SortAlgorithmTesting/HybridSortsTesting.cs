namespace SortAlgorithmTesting
{
    [TestFixture]
    public class HybridSortsTesting
    {
        [Test]
        public void BlockSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            HybridSorts.BlockSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(4096)]
        public void BlockSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Block Sort algorithm to the array
            HybridSorts.BlockSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void TimSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            HybridSorts.TimSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(4096)]
        public void TimSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Tim Sort algorithm to the array
            HybridSorts.TimSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void IntroSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            HybridSorts.IntroSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(4096)]
        public void IntroSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Intro Sort algorithm to the array
            HybridSorts.IntroSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void MergeInsertionSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            HybridSorts.MergeInsertionSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(4096)]
        public void MergeInsertionSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply MergeInsertion Sort algorithm to the array
            HybridSorts.MergeInsertionSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }
    }
}
