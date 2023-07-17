namespace task2
{
    static internal class LZW
    {
        private static readonly int MAX_ENTRIES_NUMBER = 1 << 16;
        private static int currentCodeLength = 8;
        public static void Compress(FileStream input, FileStream output)
        {
            Trie trie = new();
            trie.InitializeWithAlphabet();
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
                    if (trie.Size == MAX_ENTRIES_NUMBER)
                    {
                        trie = new();
                        trie.InitializeWithAlphabet();
                        currentCodeLength = 8;
                    }
                    if (trie.Size == (1 << currentCodeLength))
                        currentCodeLength++;
                    trie.Add(nextString, trie.Size);
                    prevString = string.Empty + currentChar;
                }
            }
            byteBuffer.Write(trie.Get(prevString), currentCodeLength);
            byteBuffer.Flush();
        }
        public static void Decompress(FileStream input, FileStream output)
        {
            Dictionary<int, string> dict = new();
            for (int i = 0; i < 256; i++)
            {
                dict[i] = string.Empty + (char)i;
            }
            IntegerBuffer intBuffer = new(input);
            int prevCode = 0;
            int curCode = 0;
            prevCode = intBuffer.Read(currentCodeLength);
            var prevWord = dict[prevCode];
            prevWord.ToList<char>().ForEach(ch => output.WriteByte((byte)ch));
            if (dict.Count == (1 << currentCodeLength))
                currentCodeLength++;
            while ((curCode = intBuffer.Read(currentCodeLength)) != -1)
            {
                string entry;
                if (dict.ContainsKey(curCode))
                    entry = dict[curCode];
                else
                    entry = prevWord + prevWord[0];
                entry.ToList<char>().ForEach(ch => output.WriteByte((byte)ch));
                if (dict.Count == MAX_ENTRIES_NUMBER)
                {
                    dict = new();
                    for (int i = 0; i < 256; i++)
                    {
                        dict[i] = string.Empty + (char)i;
                    }
                    currentCodeLength = 8;
                }
                if (dict.Count == (1 << currentCodeLength))
                    currentCodeLength++;
                dict[dict.Count] = prevWord + entry[0];
                prevCode = curCode;
            }
        }
    }
}
