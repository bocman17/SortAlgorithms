namespace SortAlgorithms.HelperClasses
{
    public class Tree<T> where T : IComparable<T>
    {
        public T Root { get; }
        public List<Tree<T>> Children { get; }

        public Tree(T root)
        {
            Root = root;
            Children = new List<Tree<T>>();
        }

        public IEnumerable<T> InOrderTraversal()
        {
            foreach (var child in Children)
            {
                foreach (var value in child.InOrderTraversal())
                {
                    yield return value;
                }
            }
            yield return Root;
        }
    }
}
