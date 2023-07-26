using System.Collections.Immutable;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using task1.Exceptions;

namespace task1
{
    internal class Program
    {
        private static (int, List<Edge>) ReadGraph(string path)
        {
            string pattern = @"^(\d+): ?(\d+ ?\(\d+\),? ?)*$";
            var lines = File.ReadAllLines(path);
            List<Edge> graph = new();
            foreach (var line in lines)
            {
                if (!Regex.IsMatch(line, pattern))
                    throw new FileFormatException();
                var integers = Regex.Split(line, @"\D+").ToList().ConvertAll(int.Parse);
                int vertex = integers[0];
                for (int i = 1; i < integers.Count; i += 2)
                {
                    int neighbour = integers[i];
                    int weight = integers[i + 1];
                    graph.Add(new Edge(vertex, neighbour, weight));
                }
            }
            return (lines.Length, graph);
        }
        private static void WriteGraph(int verticesNumber, List<Edge> graph, string path)
        {
            if (verticesNumber == 1)
            {
                File.WriteAllText(path, "1:\n");
                return;
            }
            Dictionary<int, List<(int, int)>> listsOfNeighbours = new();
            foreach (var edge in graph)
            {
                listsOfNeighbours[edge.Vertex1].Add((edge.Vertex2, edge.Weight));
            }
            StringBuilder result = new();
            foreach (var (vertex, list) in listsOfNeighbours)
            {

                string stringifiedList = string.Join(", ", list
                    .Select((neighbour, weight) => $"{neighbour} ({weight})")
                    .ToArray<string>());
                result.Append($"{vertex}: {stringifiedList}\n");
            }
            File.WriteAllText(path, result.ToString());
        }

        static int Main(string[] args)
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

                var (verticesNumber, graph) = ReadGraph(inputPath);
                var mst = MST.BuildMST(verticesNumber, graph);
                WriteGraph(verticesNumber, mst, outputPath);
            }
            catch (Exception e)
            when (e is EmptyGraphException || 
            e is GraphNotConnectedException)
            {
                Console.Error.WriteLine(e.Message);
                return 1;
            }
            catch (Exception e)
            when (e is ArgumentException ||
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