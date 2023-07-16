namespace task2
{
    static internal class LZW
    {
        private static readonly int MAX_TRIE_SIZE = 1 << 16;
        private static int currentCodeLength;
        private static Trie trie;
        private static ByteBuffer byteBuffer;

        private static void Initialize()
        {
            int currentCodeLength = 8;
            Trie trie = new();
            for (int i = 0; i < (1 << currentCodeLength); i++)
            {
                trie.Add(i.ToString(), i);
            }
        }
        public static void Compress(FileStream input, FileStream output)
        {
            Initialize();
            ByteBuffer byteBuffer = new(output);
            string prevString = string.Empty;
            int readByte = 0;
            while ((readByte = input.ReadByte()) != -1)
            {
                // treat byte like char
                char currentChar = (char)readByte;
                string nextString = prevString + currentChar;
                if (trie.Contains(nextString))
                {
                    prevString = nextString;
                }
                else
                {
                    int code = trie.Get(prevString);
                    byteBuffer.Write(code, currentCodeLength);
                    if (trie.Size == MAX_TRIE_SIZE)
                        Initialize();
                    if (trie.Size == (1 << currentCodeLength))
                        currentCodeLength++;
                    trie.Add(nextString, trie.Size);
                    prevString = string.Empty + currentChar;
                }
            }
            byteBuffer.Write(trie.Get(prevString), currentCodeLength);
            byteBuffer.Flush();
        }
    }
}
