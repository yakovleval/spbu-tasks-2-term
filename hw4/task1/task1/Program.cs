using System.Data;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("enter a path to a file (or 0 to exit):");
                string? input = Console.ReadLine();
                if (input == "0")
                    return;
                if (input == null || !File.Exists(input))
                {
                    Console.WriteLine("file doesn't exist");
                    continue;
                }

                string expression;
                try
                {
                    expression = File.ReadAllText(input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                AST tree;
                try
                {
                    tree = new AST(expression);
                    Console.WriteLine($"tree: {tree}");
                    Console.WriteLine($"result: {tree.Evaluate()}");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Error: invalid operation");
                }
                catch (InvalidExpressionException)
                {
                    Console.WriteLine("Error: invalid expression");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error: division by zero");
                }
                
            }
        }
    }
}