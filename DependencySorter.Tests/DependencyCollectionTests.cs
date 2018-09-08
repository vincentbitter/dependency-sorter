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
    }
}
