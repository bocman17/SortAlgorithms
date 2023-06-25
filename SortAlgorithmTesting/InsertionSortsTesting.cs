namespace SortAlgorithmTesting
{
    [TestFixture]
    public class InsertionSortsTesting
    {
        [Test]
        public void InsertionSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            InsertionSorts.InsertionSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void InsertionSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Bubble Sort algorithm to the array
            InsertionSorts.InsertionSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void ShellSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            InsertionSorts.ShellSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void ShellSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Shell Sort algorithm to the array
            InsertionSorts.ShellSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }
    }
}
