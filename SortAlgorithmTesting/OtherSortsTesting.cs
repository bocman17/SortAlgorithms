namespace SortAlgorithmTesting
{
    [TestFixture]
    public class OtherSortsTesting
    {
        [Test]
        public void PancakeSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            OtherSorts.PancakeSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void PancakeSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Pancake Sort algorithm to the array
            OtherSorts.PancakeSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }
    }
}
