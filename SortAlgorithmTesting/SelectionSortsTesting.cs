namespace SortAlgorithmTesting
{
    [TestFixture]
    public class SelectionSortsTesting
    {
        [Test]
        public void SelectionSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            SelectionSorts.SelectionSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void SelectionSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Bubble Sort algorithm to the array
            SelectionSorts.SelectionSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void HeapSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            SelectionSorts.HeapSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void HeapSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Heap Sort algorithm to the array
            SelectionSorts.HeapSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void CycleSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            SelectionSorts.CycleSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void CycleSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Cycle Sort algorithm to the array
            SelectionSorts.CycleSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }
    }
}
