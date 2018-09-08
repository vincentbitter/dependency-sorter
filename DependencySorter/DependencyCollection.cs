using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DependencySorter
{
    public class DependencyCollection<T> : IEnumerable<T>
    {
        private readonly IDictionary<T, IList<T>> _items;

        public DependencyCollection()
        {
            _items = new Dictionary<T, IList<T>>();
        }

        public void Add(T item, params T[] dependencies)
        {
            Add(item, dependencies.ToList());
        }

        public void Add(T item, IEnumerable<T> dependencies)
        {
            _items.Add(item, dependencies.ToList());
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
