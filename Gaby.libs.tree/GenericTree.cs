namespace Gaby.libs.tree
{
    public class GenericTree<T>
    {
        private T _nodeData;
        private List<GenericTree<T>> _children;

        public GenericTree(T nodeData)
        {
            this._nodeData = nodeData;
            _children = new List<GenericTree<T>>();
        }

        public T GetData()
        {
            return _nodeData;
        }
        public bool IsLeaf()
        {
            return _children.Count > 0;
        }

        public List<GenericTree<T>> GetChildren()
        {
            return _children;
        }
        public void RemoveChils(GenericTree<T> child)
        {
            this.GetChildren().Remove(child);
        }

        public void AddChild(GenericTree<T> child)
        {
            this._children.Add(child);
        }

    }
}
