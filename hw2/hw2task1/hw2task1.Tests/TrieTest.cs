namespace hw2task1.Tests
{
    [TestClass]
    public class TrieTest
    {
        [TestMethod]
        public void AddTest()
        {
            var trie = new Trie();
            Assert.IsFalse(trie.Contains("a"));
            bool result = trie.Add("a");
            Assert.IsTrue(trie.Contains("a"));
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DoubleAddTest()
        {
            var trie = new Trie();
            Assert.IsFalse(trie.Contains("abc"));
            Assert.IsTrue(trie.Add("abc"));
            Assert.IsFalse(trie.Add("abc"));
            Assert.IsTrue(trie.Contains("abc"));
        }
        [TestMethod]
        public void RemoveTest()
        {
            var trie = new Trie();
            Assert.IsFalse(trie.Contains("a"));
            Assert.IsTrue(trie.Add("a"));
            Assert.IsTrue(trie.Contains("a"));
            Assert.IsTrue(trie.Remove("a"));
            Assert.IsFalse(trie.Contains("a"));
        }
        [TestMethod]
        public void DoubleRemoveTest()
        {
            var trie = new Trie();
            Assert.IsFalse(trie.Contains("a"));
            Assert.IsTrue(trie.Add("a"));
            Assert.IsTrue(trie.Contains("a"));
            Assert.IsTrue(trie.Remove("a"));
            Assert.IsFalse(trie.Contains("a"));
            Assert.IsFalse(trie.Remove("a"));
            Assert.IsFalse(trie.Contains("a"));
        }
        [TestMethod]
        public void AddPrefixesTest()
        {
            var trie = new Trie();
            Assert.IsTrue(trie.Add("aab"));
            Assert.IsFalse(trie.Contains("aa"));
            Assert.IsFalse(trie.Contains("a"));

            Assert.IsTrue(trie.Add("aa"));
            Assert.IsTrue(trie.Contains("aa"));
            Assert.IsFalse(trie.Contains("a"));

            Assert.IsTrue(trie.Add("a"));
            Assert.IsTrue(trie.Contains("a"));
        }
        [TestMethod]
        public void HowManyStartsWithPrefixesTest()
        {
            var trie = new Trie();
            Assert.IsTrue(trie.Add("he"));
            Assert.IsTrue(trie.Add("she"));
            Assert.IsTrue(trie.Add("his"));
            Assert.IsTrue(trie.Add("hers"));
            Assert.IsTrue(trie.HowManyStartsWithPrefix("hers") == 1);
            Assert.IsTrue(trie.HowManyStartsWithPrefix("her") == 1);
            Assert.IsTrue(trie.HowManyStartsWithPrefix("he") == 2);
            Assert.IsTrue(trie.HowManyStartsWithPrefix("h") == 3);
            Assert.IsTrue(trie.HowManyStartsWithPrefix("hi") == 1);
            Assert.IsTrue(trie.HowManyStartsWithPrefix("his") == 1);
            Assert.IsTrue(trie.HowManyStartsWithPrefix("s") == 1);
            Assert.IsTrue(trie.HowManyStartsWithPrefix("sh") == 1);
            Assert.IsTrue(trie.HowManyStartsWithPrefix("she") == 1);
            Assert.IsTrue(trie.HowManyStartsWithPrefix("shes") == 0);
        }
        [TestMethod]
        public void SizeTest()
        {
            var trie = new Trie();
            Assert.IsTrue(trie.Add("he"));
            Assert.IsTrue(trie.Add("she"));
            Assert.IsTrue(trie.Add("his"));
            Assert.IsTrue(trie.Add("hers"));
            Assert.IsTrue(trie.Size == 4);
        }
    }
}