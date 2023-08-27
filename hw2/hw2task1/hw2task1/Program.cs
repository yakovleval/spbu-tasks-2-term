namespace hw2task1
{
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