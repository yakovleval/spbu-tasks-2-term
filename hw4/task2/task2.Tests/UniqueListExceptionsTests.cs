using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.Tests
{
    public class UniqueListExceptionsTests
    {
        private UniqueList list;
        [SetUp]
        public void SetUp() => list = new UniqueList();
        [Test]
        public void TestAddExistingElement()
        {
            list.Add(1);
            Assert.Throws<AdditionOfExistentElementException>(() => list.Add(1));
        }
        [Test]
        public void TestRemoveFromEmptyList()
        {
            Assert.Throws<DeletingNonExistingElementException>(() => list.Remove(1));
        }
        [Test]
        public void TestRemoveNonExistentElement()
        {
            list.Add(1);
            list.Add(2);
            Assert.Throws<DeletingNonExistingElementException>(() => list.Remove(3));
        }
    }
}
