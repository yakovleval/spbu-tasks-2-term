namespace Task1.Exceptions
{
    public class FileFormatException : Exception
    {
        public FileFormatException(string message = "invalid file format") : base(message) { }
    }
}
