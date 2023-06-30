namespace SortAlgorithms.HelperClasses
{
    // A binary tree node has value, pointer to left child, and a pointer to right child
    public class Node
    {
        public int Value { get; set; }

        public Node? Left { get; set; }

        public Node? Right { get; set; }

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

    }
}
