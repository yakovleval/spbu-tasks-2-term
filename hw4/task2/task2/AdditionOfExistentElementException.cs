namespace Task2
{
    public class AdditionOfExistentElementException : Exception
    {
        public AdditionOfExistentElementException() { }
        public AdditionOfExistentElementException(string message) : base(message) { }
    }
}
