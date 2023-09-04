namespace Task2
{
    internal class Program
    {
        private static readonly string helpMessage = """

            usage: dotnet run [<path to file>] [<option>]

            --c  compress file
            --u  decompress file (must have '.zipped' extension)
            """;

        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine(helpMessage);
                return;
            }
            string path = args[0];
            string option = args[1];
            byte[] fileBytes;
            try
            {
                fileBytes = File.ReadAllBytes(path);
                switch (option)
                {
                    case "--c":
                        Console.WriteLine("compressing...");
                        byte[] compressedBytes = LZW.Compress(fileBytes);
                        string compressedFilePath = path + ".zipped";
                        File.WriteAllBytes(compressedFilePath, compressedBytes);
                        Console.WriteLine("done! Compression rate: {0:0.00}",
                            (double)compressedBytes.Length / fileBytes.Length);
                        break;
                    case "--u":
                        if (!path.EndsWith(".zipped"))
                            throw new ArgumentException("file does not have '.zipped' extension");
                        Console.WriteLine("decompressing...");
                        byte[] decompressedBytes = LZW.Decompress(fileBytes);
                        string decompressedFilePath = path.Replace(".zipped", string.Empty);
                        File.WriteAllBytes(decompressedFilePath, decompressedBytes);
                        Console.WriteLine("done!");
                        break;
                    default:
                        throw new ArgumentException("incorrect option");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(helpMessage);
            }
        }
    }
}
