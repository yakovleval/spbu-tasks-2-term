namespace hw2task1
{
    public class Trie
    {
        private Node root;
        public int Size { get { return HowManyStartsWithPrefix(""); } }

        public Trie()
        {
            root = new Node();
        }

        public bool Add(string element)
        {
            if (Contains(element))
            {
                return false;
            }
            Node node = root;
            foreach (char c in element)
            {
                if (!node.children.ContainsKey(c))
                {
                    node.children[c] = new Node();
                }

                node.count++;
                node = node.children[c];
            }

            node.count++;
            node.isEndOfWord = true;
            return true;
        }

        public bool Contains(string element)
        {
            Node node = root;

            foreach (char c in element)
            {
                if (!node.children.ContainsKey(c))
                {
                    return false;
                }
                node = node.children[c];
            }
            return node.isEndOfWord;
        }

        public bool Remove(string element)
        {
            if (!Contains(element))
            {
                return false;
            }
            Node node = root;

            foreach (char c in element)
            {
                node.count--;
                node = node.children[c];
            }

            node.count--;

            node.isEndOfWord = false;
            return true;
        }

        public int HowManyStartsWithPrefix(string prefix)
        {
            Node node = root;

            foreach (char c in prefix)
            {
                if (!node.children.ContainsKey(c))
                {
                    return 0;
                }

                node = node.children[c];
            }

            return node.count;
        }

        private class Node
        {
            public Dictionary<char, Node> children;
            public bool isEndOfWord;
            public int count;

            public Node()
            {
                children = new Dictionary<char, Node>();
                isEndOfWord = false;
                count = 0;
            }
        }
    }
}
