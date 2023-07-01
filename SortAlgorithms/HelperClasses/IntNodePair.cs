namespace SortAlgorithms.HelperClasses
{
    // Pair to store the node value and corresponding node
    public class IntNodePair : IComparable<IntNodePair>
    {
        public int first;
        public Node? second;

        public IntNodePair(int f, Node s)
        {
            first = f;
            second = s;
        }

        public int CompareTo(IntNodePair? other)
        {
            if (other is not null)
            {
                return first.CompareTo(other.first);
            }
            return 1;
        }
    }
}
