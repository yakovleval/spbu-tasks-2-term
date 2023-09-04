namespace Task1.Exceptions
{
    public class EmptyGraphException : Exception
    {
        public EmptyGraphException(string message = "Graph cannot be empty") : base(message) { }
    }
}
