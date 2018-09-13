using System;
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
            var result = new List<T>();
            while (_items.Count > result.Count)
            {
                var newItems = _items
                    .Where(i => !result.Contains(i.Key)) // Not already added
                    .Where(i => i.Value.All(d => result.Contains(d) || !_items.Keys.Contains(d))) // All dependencies already included or do not exist
                    .Select(i => i.Key)
                    .ToList();
                if (!newItems.Any())
                    throw new Exception("Invalid dependencies!");

                result.AddRange(newItems);
            }
            return result.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
