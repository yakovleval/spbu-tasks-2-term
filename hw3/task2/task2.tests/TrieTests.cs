namespace task2.tests
{
    [TestClass]
    public class TrieTests
    {
        [TestMethod]
        public void TestInitializationByDictionaryAndGet()
        {
            Trie trie = new(new Dictionary<string, int>
            {
                { "a", 1 }
            });
            Assert.AreEqual(trie.Get("a"), 1);
        }

        [TestMethod]
        public void TestInitializationByDictionaryAndContains()
        {
            Trie trie = new(new Dictionary<string, int>
            {
                { "a", 1 }
            });
            Assert.IsTrue(trie.Contains("a"));
        }
        [TestMethod]
        public void TestAddAndGet()
        {
            Trie trie = new();
            Assert.IsTrue(trie.Add("a", 1));
            Assert.AreEqual(trie.Get("a"), 1);
        }

        [TestMethod]
        public void TestAddAndContains()
        {
            Trie trie = new();
            Assert.IsTrue(trie.Add("a", 1));
            Assert.IsTrue(trie.Contains("a"));
        }
        [TestMethod]
        public void TestAddAndRemove()
        {
            Trie trie = new();
            Assert.IsTrue(trie.Add("a", 1));
            Assert.IsTrue(trie.Remove("a"));
        }
        [TestMethod]
        public void TestRemoveAndContains()
        {
            Trie trie = new();
            Assert.IsTrue(trie.Add("a", 1));
            Assert.IsTrue(trie.Remove("a"));
            Assert.IsFalse(trie.Contains("a"));
        }
        [TestMethod]
        public void TestGetNonExistentKey()
        {
            Trie trie = new();
            Assert.ThrowsException<KeyNotFoundException>(() => trie.Get("abc"));
        }
        [TestMethod]
        public void TestInitializationAndSize()
        {
            Trie trie = new(new Dictionary<string, int>
            {
                { "a", 1 },
                { "b", 2 },
                { "c", 3 },
                { "d", 4 }
            });
            Assert.AreEqual(trie.Size, 4);
        }
        [TestMethod]
        public void TestRemoveAndSize()
        {
            Trie trie = new(new Dictionary<string, int>
            {
                { "a", 1 },
                { "b", 2 },
                { "c", 3 },
                { "d", 4 }
            });
            Assert.AreEqual(trie.Size, 4);
            Assert.IsTrue(trie.Remove("a"));
            Assert.IsTrue(trie.Remove("b"));
            Assert.IsTrue(trie.Remove("c"));
            Assert.IsTrue(trie.Remove("d"));
            Assert.AreEqual(trie.Size, 0);

        }
    }
}