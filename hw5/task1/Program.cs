using System.Security;
using Task1.Exceptions;

namespace Task1
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    Console.WriteLine("""
                        usage: dotnet run [<path to input file>] [<path to output file>]
                        """);
                    return 0;
                }
                string inputPath = args[0];
                string outputPath = args[1];

                var (verticesNumber, graph) = FileIO.ReadGraph(inputPath);
                var mst = MST.BuildMST(verticesNumber, graph);
                File.WriteAllText(outputPath, FileIO.PrintGraph(verticesNumber, mst));
            }
            catch (Exception e)
            when (e is EmptyGraphException ||
            e is GraphNotConnectedException)
            {
                Console.Error.WriteLine(e.Message);
                return 1;
            }
            catch (Exception e)
            when (e is FileFormatException ||
            e is ArgumentException ||
            e is ArgumentNullException ||
            e is PathTooLongException ||
            e is DirectoryNotFoundException ||
            e is IOException ||
            e is UnauthorizedAccessException ||
            e is FileNotFoundException ||
            e is NotSupportedException ||
            e is SecurityException)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            return 0;
        }
    }
}
