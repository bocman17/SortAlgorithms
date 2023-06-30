namespace SortAlgorithms.HelperClasses
{
    public class PriorityQueueTournament<T>
    {
        private List<T> heap;
        private IComparer<T> _comparer;

        public int Count { get { return heap.Count; } }

        public PriorityQueueTournament(int capacity, IComparer<T> comparer = null)
        {
            heap = new List<T>(capacity);
            _comparer = comparer ?? Comparer<T>.Default;
        }

        public void Enqueue(T item)
        {
            heap.Add(item);
            int childIndex = heap.Count - 1;
            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (_comparer.Compare(heap[childIndex], heap[parentIndex]) >= 0)
                    break;
                Swap(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            int lastIndex = heap.Count - 1;
            T firstItem = heap[0];
            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);

            int currentIndex = 0;
            while (true)
            {
                int leftChildIndex = currentIndex * 2 + 1;
                int rightChildIndex = currentIndex * 2 + 2;
                if (leftChildIndex >= heap.Count)
                    break;

                int minIndex = leftChildIndex;
                if (rightChildIndex < heap.Count && _comparer.Compare(heap[rightChildIndex], heap[leftChildIndex]) < 0)
                    minIndex = rightChildIndex;

                if (_comparer.Compare(heap[currentIndex], heap[minIndex]) <= 0)
                    break;

                Swap(currentIndex, minIndex);
                currentIndex = minIndex;
            }

            return firstItem;
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
