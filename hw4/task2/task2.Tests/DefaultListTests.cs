using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.Tests
{
    public class DefaultListTests
    {
        private DefaultList list;
        [SetUp]
        public void SetUp() => list = new DefaultList();
        [Test]
        public void TestAddExistingElement()
        {
            list.Add(1);
            list.Add(1);
        }

        [Test]
        public void TestRemoveFromEmptyList()
        {
            Assert.IsFalse(list.Remove(1));
        }
        [Test]
        public void TestRemoveNonExistentElement()
        {
            list.Add(1);
            list.Add(2);
            Assert.IsFalse(list.Remove(3));
        }
    }
}
