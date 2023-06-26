namespace SortAlgorithmTesting
{
    [TestFixture]
    public class ImpracticalSortsTesting
    {
        [Test]
        public void BogoSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ImpracticalSorts.BogoSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(5)]
        [TestCase(8)]
        [TestCase(10)]
        public void BogoSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Bogo Sort algorithm to the array
            ImpracticalSorts.BogoSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void StoogeSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ImpracticalSorts.StoogeSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(5)]
        [TestCase(8)]
        [TestCase(10)]
        public void StoogeSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Stooge Sort algorithm to the array
            ImpracticalSorts.StoogeSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void SlowSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ImpracticalSorts.SlowSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(5)]
        [TestCase(8)]
        [TestCase(10)]
        public void SlowSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Slow Sort algorithm to the array
            ImpracticalSorts.SlowSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }
    }
}
