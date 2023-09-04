namespace Task1.Exceptions
{
    public class GraphNotConnectedException : Exception
    {
        public GraphNotConnectedException(string message = "Graph is not connected") : base(message) { }
    }
}
