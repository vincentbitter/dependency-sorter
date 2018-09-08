using System.Collections;
using System.Collections.Generic;

namespace DependencySorter
{
    public class DependencyCollection<T> : IEnumerable<T>
    {
        private readonly IDictionary<T, IList<T>> _items;

        public DependencyCollection()
        {
            _items = new Dictionary<T, IList<T>>();
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
