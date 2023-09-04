namespace Task2
{
    /// <summary>
    /// search tree, key-value data structure with string keys and integer values
    /// </summary>
    public class Trie
    {
        private class Node
        {
            public Dictionary<char, Node> children = new();
            public bool isKey = false;
            public int keysNumberInSubtree = 0;
            public int value = -1;
        }
        private Node root = new();
        /// <summary>
        /// number of keys in the Trie
        /// </summary>
        public int Size { get { return root.keysNumberInSubtree; } }
        public Trie() { }
        public void InitializeWithAllChars()
        {
            for (int i = 0; i < 256; i++)
            {
                Add(string.Empty + (char)i, i);
            }
        }
        /// <summary>
        /// Adds (key, value) pair to the Trie
        /// </summary>
        /// <param name="key">key to add</param>
        /// <param name="value">corresponding value to add</param>
        /// <returns>true if the pair was added, false otherwise</returns>
        public bool Add(string key, int value)
        {
            if (Contains(key))
            {
                return false;
            }
            Node node = root;
            foreach (char c in key)
            {
                if (!node.children.ContainsKey(c))
                {
                    node.children[c] = new Node();
                }

                node.keysNumberInSubtree++;
                node = node.children[c];
            }

            node.keysNumberInSubtree++;
            node.isKey = true;
            node.value = value;
            return true;
        }
        /// <summary>
        /// searches for a key in Trie
        /// </summary>
        /// <param name="key">key to search for</param>
        /// <returns>true if Trie contains the key, false otherwise</returns>
        public bool Contains(string key)
        {
            Node node = root;

            foreach (char c in key)
            {
                if (!node.children.ContainsKey(c))
                {
                    return false;
                }
                node = node.children[c];
            }
            return node.isKey;
        }
        /// <summary>
        /// Gets a value by a given key
        /// </summary>
        /// <param name="key">key to find value for</param>
        /// <returns>a corresponding value of the key</returns>
        /// <exception cref="KeyNotFoundException">thrown when given key is not found in Trie</exception>
        public int Get(string key)
        {
            Node node = root;

            foreach (char c in key)
            {
                if (!node.children.ContainsKey(c))
                {
                    throw new KeyNotFoundException();
                }
                node = node.children[c];
            }
            if (node.isKey)
                return node.value;
            throw new KeyNotFoundException();
        }
        /// <summary>
        /// removes (key, value) pair from Trie
        /// </summary>
        /// <param name="key">key to remove</param>
        /// <returns>if the corresponding pair was removed</returns>
        public bool Remove(string key)
        {
            if (!Contains(key))
            {
                return false;
            }
            Node node = root;

            foreach (char c in key)
            {
                node.keysNumberInSubtree--;
                node = node.children[c];
            }

            node.keysNumberInSubtree--;

            node.isKey = false;
            return true;
        }
    }
}
