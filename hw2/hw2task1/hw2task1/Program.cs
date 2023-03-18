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


    internal class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();
            while (true)
            {
                Console.WriteLine("enter the command: 0 - exit, 1 - Add, 2 - Contains, 3 - Remove, 4 - HowManyStartsWithPrefix");
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 0:
                        return;
                    case 1:
                        {
                            Console.WriteLine("enter the element to add:");
                            var element = Console.ReadLine();
                            Console.WriteLine("result: " + trie.Add(element));
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("enter the element to find:");
                            var element = Console.ReadLine();
                            Console.WriteLine("result: " + trie.Contains(element));
                            break;

                        }
                    case 3:
                        {
                            Console.WriteLine("enter the element to remove:");
                            var element = Console.ReadLine();
                            Console.WriteLine("result: " + trie.Remove(element));
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("enter the prefix to count:");
                            var element = Console.ReadLine();
                            Console.WriteLine("result: " + trie.HowManyStartsWithPrefix(element));
                            break;

                        }
                    default:
                        {
                            Console.WriteLine("unknown command");
                            break;
                        }
                }
            }
        }
    }
}