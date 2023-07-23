namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("enter the path to the file:");
                string? path = Console.ReadLine();
                if (path == null || !File.Exists(path))
                {
                    Console.WriteLine("file doesn't exist");
                    continue;
                }
            }
        }
    }
}