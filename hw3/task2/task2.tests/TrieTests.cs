namespace task2.tests
{
    [TestClass]
    public class TrieTests
    {
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
        public void TestRemoveAndSize()
        {
            Trie trie = new();
            Assert.IsTrue(trie.Add("a", 1));
            Assert.IsTrue(trie.Add("b", 2));
            Assert.IsTrue(trie.Add("c", 3));
            Assert.IsTrue(trie.Add("d", 4));
            Assert.AreEqual(trie.Size, 4);
            Assert.IsTrue(trie.Remove("a"));
            Assert.IsTrue(trie.Remove("b"));
            Assert.IsTrue(trie.Remove("c"));
            Assert.IsTrue(trie.Remove("d"));
            Assert.AreEqual(trie.Size, 0);

        }
        [TestMethod]
        public void TestGetPrefixOfExistentKey()
        {
            Trie trie = new();
            trie.Add("abcd", 1);
            Assert.ThrowsException<KeyNotFoundException>(() => trie.Get("abc"));
        }
        [TestMethod]
        public void TestInitializeWithAllCharsAndSize()
        {
            Trie trie = new();
            trie.InitializeWithAllChars();
            Assert.AreEqual(256, trie.Size);
        }
    }
}