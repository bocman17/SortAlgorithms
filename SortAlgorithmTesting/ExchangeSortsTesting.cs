namespace SortAlgorithmTesting
{
    [TestFixture]
    public class ExchangeSortsTesting
    {
        [Test]
        public void BubbleSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ExchangeSorts.BubbleSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void BubbleSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Bubble Sort algorithm to the array
            ExchangeSorts.BubbleSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void CoctailShakeSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ExchangeSorts.CoctailShakerSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void CoctailShakeSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply CoctailShake Sort algorithm to the array
            ExchangeSorts.CoctailShakerSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void OddEvenSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ExchangeSorts.OddEvenSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void OddEvenSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply OddEven Sort algorithm to the array
            ExchangeSorts.OddEvenSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void CombSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ExchangeSorts.CombSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void CombSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Comb Sort algorithm to the array
            ExchangeSorts.CombSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void GnomeSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ExchangeSorts.GnomeSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void GnomeSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Gnome Sort algorithm to the array
            ExchangeSorts.GnomeSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void PESortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ExchangeSorts.PESort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void PESortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply PE Sort algorithm to the array
            ExchangeSorts.PESort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }

        [Test]
        public void QuickSortArrayIsEmptyTest()
        {

            int[] arr = Array.Empty<int>();

            ExchangeSorts.QuickSort(arr);
            Assert.That(arr, Is.Empty);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void QuickSortMultiTest(int arraySize)
        {
            // Generate random array
            int min = -1000000;
            int max = 1000000;
            var arr = TestHelper.GenerateRandomArray(arraySize, min, max);

            // Create a sorted copy
            var expected = arr.ToArray();
            Array.Sort(expected);

            // Apply Quick Sort algorithm to the array
            ExchangeSorts.QuickSort(arr);

            // Assert that the sorted array matches the expected sorted array
            CollectionAssert.AreEqual(expected, arr);
        }
    }
}
