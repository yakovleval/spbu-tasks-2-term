using task1.Exceptions;

namespace task1
{
    /// <summary>
    /// class that helps to build a maximum spanning tree
    /// </summary>
    public static class MST
    {
        /// <summary>
        /// builds a maximum spanning tree using Prim's algorithm
        /// </summary>
        /// <param name="verticesNumber">number of vertices in the graph</param>
        /// <param name="graph">list of edges of the graph</param>
        /// <returns>list of edges of the maximum spanning tree</returns>
        /// <exception cref="EmptyGraphException">thrown if graph is empty</exception>
        /// <exception cref="GraphNotConnectedException">thrown if graph is not connected</exception>
        public static List<Edge> BuildMST(int verticesNumber, List<Edge> graph)
        {
            if (verticesNumber == 0)
                throw new EmptyGraphException();
            List<Edge> tree = new();
            HashSet<int> coveredVertices = new HashSet<int> { 1 };
            for (int i = 0; i < verticesNumber - 1; i++)
            {
                Edge maxEdge = new(0, 0, -1);
                foreach (var edge in graph)
                {
                    if (coveredVertices.Contains(edge.Vertex1) &&
                        !coveredVertices.Contains(edge.Vertex2) &&
                        edge.Weight > maxEdge.Weight)
                        maxEdge = edge;
                }
                if (maxEdge.Weight == -1)
                    throw new GraphNotConnectedException();
                tree.Add(maxEdge);
                coveredVertices.Add(maxEdge.Vertex2);
            }
            return tree;
        }
    }
}
