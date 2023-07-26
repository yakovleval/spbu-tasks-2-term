using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using task1.Exceptions;

namespace task1
{
    public static class FileIO
    {
        public static (int, List<Edge>) ReadGraph(string path)
        {
            string pattern = @"^(\d+): ?(\d+ ?\(\d+\),? ?)*$";
            var lines = File.ReadAllLines(path);
            List<Edge> graph = new();
            HashSet<int> vertices = new();
            foreach (var line in lines)
            {
                if (!Regex.IsMatch(line, pattern))
                    throw new FileFormatException();
                var intsInStrings = Regex.Split(line, @"\D+").ToList();
                intsInStrings.RemoveAll(str => str == "");
                var integers = intsInStrings.ConvertAll(int.Parse);
                int vertex = integers[0];
                if (!vertices.Contains(vertex))
                    vertices.Add(vertex);
                for (int i = 1; i < integers.Count; i += 2)
                {
                    int neighbour = integers[i];
                    int weight = integers[i + 1];
                    graph.Add(new Edge(vertex, neighbour, weight));
                    if (!vertices.Contains(neighbour))
                        vertices.Add(neighbour);
                }
            }
            return (vertices.Count, graph);
        }
        public static string PrintGraph(int verticesNumber, List<Edge> graph)
        {
            if (verticesNumber == 1)
            {
                return "1:\n";
            }
            Dictionary<int, List<(int, int)>> listsOfNeighbours = new();
            foreach (var edge in graph)
            {
                if (!listsOfNeighbours.ContainsKey(edge.Vertex1))
                    listsOfNeighbours[edge.Vertex1] = new();
                listsOfNeighbours[edge.Vertex1].Add((edge.Vertex2, edge.Weight));
            }
            StringBuilder result = new();
            foreach (var (vertex, list) in listsOfNeighbours)
            {

                string stringifiedList = string.Join(", ", list
                    .Select(pair => $"{pair.Item1} ({pair.Item2})")
                    .ToArray<string>());
                result.Append($"{vertex}: {stringifiedList}\n");
            }
            return result.ToString();
        }

    }
}
