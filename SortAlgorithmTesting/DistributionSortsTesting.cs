namespace SortAlgorithmTesting
{
    [TestFixture]
    public class DistributionSortsTesting
    {
        [Test]
        public void AmericanFlagSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            DistributionSorts.AmericanFlagSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void AmericanFlagSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply AmericanFlag Sort algorithm to the array
            DistributionSorts.AmericanFlagSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void BeadSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            DistributionSorts.BeadSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void BeadSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000;
            int max = 1000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Bead Sort algorithm to the array
            DistributionSorts.BeadSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void BucketSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            DistributionSorts.BucketSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void BucketSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1_000_000;
            int max = 1_000_000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Bucket Sort algorithm to the array
            DistributionSorts.BucketSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void CountingSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            DistributionSorts.CountingSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void CountingSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1_000_000;
            int max = 1_000_000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Counting Sort algorithm to the array
            DistributionSorts.CountingSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void FlashSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            DistributionSorts.FlashSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void FlashSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1_000_000;
            int max = 1_000_000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Flash Sort algorithm to the array
            DistributionSorts.FlashSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void InterpolationSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            DistributionSorts.InterpolationSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void InterpolationSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1_000_000;
            int max = 1_000_000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Interpolation Sort algorithm to the array
            DistributionSorts.InterpolationSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void PigeonHoleSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            DistributionSorts.PigeonholeSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void PigeonHoleSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1_000_000;
            int max = 1_000_000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply PigeonHole Sort algorithm to the array
            DistributionSorts.PigeonholeSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void ProxMapSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            DistributionSorts.ProxMapSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void ProxMapSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1_000_000;
            int max = 1_000_000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply ProxMap Sort algorithm to the array
            DistributionSorts.ProxMapSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void RadixSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            DistributionSorts.RadixSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void RadixSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1_000_000;
            int max = 1_000_000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Radix Sort algorithm to the array
            DistributionSorts.RadixSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }
    }
}
