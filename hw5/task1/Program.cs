using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using task1.Exceptions;

namespace task1
{
    internal class Program
    {
        private static (int, List<Edge>) ReadGraph(string path)
        {
            string pattern = @"^(\d+): ?(\d+ ?\(\d+\),? ?)+$";
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
        private static void WriteGraph(List<Edge> graph, string path)
        {
            Dictionary<int, List<(int, int)>> listsOfNeighbours = new();
            foreach (var edge in graph)
            {
                listsOfNeighbours[edge.Vertex1].Add((edge.Vertex2, edge.Weight));
            }
            foreach (var (vertex, list) in listsOfNeighbours)
            {

                string stringifiedList = string.Join(", ", list
                    .Select((neighbour, weight) => $"{neighbour} ({weight})")
                    .ToArray<string>());
                Console.WriteLine($"{vertex}: {stringifiedList}");
            }
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
                var MSTtree = MST.BuildMST(verticesNumber, graph);
                WriteGraph(MSTtree, outputPath);
            }


        }
    }
}