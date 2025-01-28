namespace Gaby.libs.tree
{
    public class GenericQueue<T>
    {
        private List<T> _data;

        public GenericQueue()
        {
            _data = new List<T>();
        }

        public void Enqueue(T item)
        {
            _data.Add(item);
        }

        public T Dequeue()
        {
            T item = this._data[0];
            _data.RemoveAt(0);

            return item;
        }

        public T Top()
        {
            return this._data[0];
        }

        public bool IsEmpty()
        {
            return _data.Count == 0;
        }

        public List<T> GetData()
        {
            return _data;
        }
    }
}
