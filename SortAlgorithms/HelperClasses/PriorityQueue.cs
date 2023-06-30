namespace SortAlgorithms.HelperClasses
{
    // Custom implementation of PriorityQueue for C#
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T>? _heap;
        private List<T>? _minHeap;
        private IComparer<T>? _comparer;

        public int Count
        {
            get
            {
                if (_heap is not null)
                {
                    return _heap.Count;
                }
                return 0;
            }
        }
        public int MinHeapCount
        {
            get
            {
                if (_minHeap is not null)
                {
                    return _minHeap.Count;
                }
                return 0;
            }
        }

        public PriorityQueue()
        {
            _heap = new List<T>();
        }

        public PriorityQueue(int capacity, IComparer<T>? comparer = null)
        {
            _minHeap = new List<T>(capacity);
            _comparer = comparer ?? Comparer<T>.Default;
        }

        public void Enqueue(T item)
        {
            if (_heap is not null)
            {
                _heap.Add(item);
                HeapifyUp(_heap.Count - 1);
            }
        }

        public void EnqueueMinHeap(T item)
        {
            if (_minHeap is not null)
            {
                _minHeap.Add(item);
                int childIndex = _minHeap.Count - 1;
                while (childIndex > 0)
                {
                    int parentIndex = (childIndex - 1) / 2;
                    if (_comparer is not null && _comparer.Compare(_minHeap[childIndex], _minHeap[parentIndex]) >= 0)
                    {
                        break;
                    }
                    SwapMinHeap(childIndex, parentIndex);
                    childIndex = parentIndex;
                }
            }
        }


        public T Dequeu()
        {
            if (_heap is null || _heap.Count == 0)
            {
                throw new InvalidOperationException("Priority queue is empty");
            }

            T firstItem = _heap[0];
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            HeapifyDown(0);
            return firstItem;
        }

        public T DequeueMinHeap()
        {
            if(_minHeap is null)
            {
                throw new InvalidOperationException("Invalid operation, heap is null");
            }
            int lastIndex = _minHeap.Count - 1;
            T firstItem = _minHeap[0];
            _minHeap[0] = _minHeap[lastIndex];
            _minHeap.RemoveAt(lastIndex);

            int currentIndex = 0;
            while (true)
            {
                int leftChildIndex = currentIndex * 2 + 1;
                int rightChildIndex = currentIndex * 2 + 2;
                if (leftChildIndex >= _minHeap.Count)
                    break;

                int minIndex = leftChildIndex;
                if (_comparer is not null && rightChildIndex < _minHeap.Count 
                    && _comparer.Compare(_minHeap[rightChildIndex], _minHeap[leftChildIndex]) < 0)
                    minIndex = rightChildIndex;

                if (_comparer is not null && _comparer.Compare(_minHeap[currentIndex], _minHeap[minIndex]) <= 0)
                    break;

                SwapMinHeap(currentIndex, minIndex);
                currentIndex = minIndex;
            }

            return firstItem;
        }

        public bool IsEmpty()
        {
            if(_heap is null)
            {
                throw new InvalidOperationException("Invalid operation, heap is null");
            }
            return _heap.Count == 0;
        }
        private void HeapifyUp(int childIndex)
        {
            if (childIndex == 0)
            {
                return;
            }
            int parentIndex = (childIndex - 1) / 2;
            if (_heap is not null && _heap[childIndex].CompareTo(_heap[parentIndex]) < 0)
            {
                Swap(childIndex, parentIndex);
                HeapifyUp(parentIndex);
            }
        }
        private void HeapifyDown(int parentIndex)
        {
            int leftChildIndex = (2 * parentIndex) + 1;
            int rightChildIndex = (2 * parentIndex) + 2;
            int smallestIndex = parentIndex;

            if (_heap is not null && 
                leftChildIndex < _heap.Count && _heap[leftChildIndex].CompareTo(_heap[smallestIndex]) < 0)
            {
                smallestIndex = leftChildIndex;
            }

            if (_heap is not null && 
                rightChildIndex < _heap.Count && _heap[rightChildIndex].CompareTo(_heap[smallestIndex]) < 0)
            {
                smallestIndex = rightChildIndex;
            }

            if (smallestIndex != parentIndex)
            {
                Swap(parentIndex, smallestIndex);
                HeapifyDown(smallestIndex);
            }
        }

        private void Swap(int index1, int index2)
        {
            if(_heap is null)
            {
                return;
            }
            (_heap[index2], _heap[index1]) = (_heap[index1], _heap[index2]);
        }

        private void SwapMinHeap(int index1, int index2)
        {
            if (_minHeap is null)
            {
                return;
            }
            (_minHeap[index2], _minHeap[index1]) = (_minHeap[index1], _minHeap[index2]);
        }
    }
}
