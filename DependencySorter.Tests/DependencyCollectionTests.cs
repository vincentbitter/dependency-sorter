using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencySorter.Tests
{
    [TestClass]
    public class DependencyCollectionTests
    {
        [TestMethod]
        public void can_initiate_a_new_instance_of_DependencyCollection_with_type_string()
        {
            var collection = new DependencyCollection<string>();
            Assert.IsNotNull(collection);
        }

        [TestMethod]
        public void can_initiate_a_new_instance_of_DependencyCollection_with_type_int()
        {
            var collection = new DependencyCollection<int>();
            Assert.IsNotNull(collection);
        }

        [TestMethod]
        public void can_initiate_a_new_instance_of_DependencyCollection_with_type_Type()
        {
            var collection = new DependencyCollection<Type>();
            Assert.IsNotNull(collection);
        }

        [TestMethod]
        public void new_instance_of_DependencyCollection_is_empty()
        {
            var collection = new DependencyCollection<string>();
            Assert.AreEqual(0, collection.Count());
        }

        [TestMethod]
        public void one_item_without_dependencies_can_be_added()
        {
            var collection = new DependencyCollection<string>();
            collection.Add("test");
            Assert.AreEqual(1, collection.Count());
        }

        [TestMethod]
        public void ten_items_without_dependencies_can_be_added()
        {
            var collection = new DependencyCollection<string>();
            Enumerable.Range(1, 10)
                .Select(i => $"item{i}")
                .ToList()
                .ForEach(s => collection.Add(s));

            var list = collection.ToList();
            Assert.AreEqual(10, list.Count);
            CollectionAssert.Contains(list, "item1");
            CollectionAssert.Contains(list, "item2");
            CollectionAssert.Contains(list, "item3");
            CollectionAssert.Contains(list, "item4");
            CollectionAssert.Contains(list, "item5");
            CollectionAssert.Contains(list, "item6");
            CollectionAssert.Contains(list, "item7");
            CollectionAssert.Contains(list, "item8");
            CollectionAssert.Contains(list, "item9");
            CollectionAssert.Contains(list, "item10");
        }

        [TestMethod]
        public void item_with_previously_added_dependency_can_be_added()
        {
            var collection = new DependencyCollection<string>();
            collection.Add("test");
            collection.Add("test2", "test");

            var list = collection.ToList();
            Assert.AreEqual(2, list.Count);
            CollectionAssert.Contains(list, "test");
            CollectionAssert.Contains(list, "test2");
        }

        [TestMethod]
        public void item_with_previously_added_dependencies_can_be_added()
        {
            var collection = new DependencyCollection<string>();
            collection.Add("test");
            collection.Add("test2");
            collection.Add("test3", "test", "test2");

            var list = collection.ToList();
            Assert.AreEqual(3, list.Count);
            CollectionAssert.Contains(list, "test");
            CollectionAssert.Contains(list, "test2");
            CollectionAssert.Contains(list, "test3");
        }

        [TestMethod]
        public void items_with_previously_added_dependencies_can_be_added()
        {
            var collection = new DependencyCollection<string>();
            collection.Add("test");
            collection.Add("test2");
            collection.Add("test3", "test", "test2");
            collection.Add("test4", "test3", "test2");

            var list = collection.ToList();
            Assert.AreEqual(4, list.Count);
            CollectionAssert.Contains(list, "test");
            CollectionAssert.Contains(list, "test2");
            CollectionAssert.Contains(list, "test3");
            CollectionAssert.Contains(list, "test4");
        }

        [TestMethod]
        public void item_with_unknown_dependencies_can_be_added()
        {
            var collection = new DependencyCollection<string>();
            collection.Add("test", "test2");

            var list = collection.ToList();
            Assert.AreEqual(1, list.Count);
            CollectionAssert.Contains(list, "test");
        }

        [TestMethod]
        public void items_with_circular_dependencies_can_be_added()
        {
            var collection = new DependencyCollection<string>();
            collection.Add("test", "test2");
            collection.Add("test2", "test");

            var list = collection.ToList();
            Assert.AreEqual(2, list.Count);
            CollectionAssert.Contains(list, "test");
            CollectionAssert.Contains(list, "test2");
        }
    }
}
