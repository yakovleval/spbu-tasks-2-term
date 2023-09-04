namespace task2
{
    public class DeletingNonExistingElementException : Exception
    {
        public DeletingNonExistingElementException() { }
        public DeletingNonExistingElementException(string message) : base(message) { }
    }
}
