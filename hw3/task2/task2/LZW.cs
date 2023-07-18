namespace task2
{
    static public class LZW
    {
        private static readonly int MAX_ENTRIES_NUMBER = 1 << 16;
        public static byte[] Compress(byte[] input)
        {
            WriteBuffer byteBuffer = new();
            int currentCodeLength = 8;
            Trie trie = new();
            trie.InitializeWithAllChars();
            string prevString = string.Empty;
            foreach (var curByte in input)
            {
                char currentChar = (char)curByte;
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
                        trie.InitializeWithAllChars();
                        currentCodeLength = 8;
                    }
                    if (trie.Size == (1 << currentCodeLength))
                        currentCodeLength++;
                    trie.Add(nextString, trie.Size);
                    prevString = string.Empty + currentChar;
                }
            }
            if (prevString != string.Empty)
            {
                byteBuffer.Write(trie.Get(prevString), currentCodeLength);
                byteBuffer.Flush();
            }
            return byteBuffer.CompressedBytes.ToArray();
        }
        public static byte[] Decompress(byte[] input)
        {
            int currentCodeLength = 8;
            Dictionary<int, string> dict = new();
            for (int i = 0; i < 256; i++)
            {
                dict[i] = string.Empty + (char)i;
            }
            ReadBuffer intBuffer = new(input);
            List<byte> output = new(); 
            int prevCode = 0;
            int curCode = 0;
            prevCode = intBuffer.Read(currentCodeLength);
            if (prevCode == -1)
                return output.ToArray();
            var prevWord = dict[prevCode];
            prevWord.ToList<char>().ForEach(ch => output.Add((byte)ch));
            if (dict.Count == (1 << currentCodeLength))
                currentCodeLength++;
            while ((curCode = intBuffer.Read(currentCodeLength)) != -1)
            {
                string curWord;
                if (dict.ContainsKey(curCode))
                    curWord = dict[curCode];
                else
                    curWord = prevWord + prevWord[0];
                curWord.ToList<char>().ForEach(ch => output.Add((byte)ch));
                dict[dict.Count] = prevWord + curWord[0];
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
                prevCode = curCode;
                prevWord = curWord;
            }
            return output.ToArray();
        }
    }
}
