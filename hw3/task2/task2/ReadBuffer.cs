namespace Task2
{
    /// <summary>
    /// this class helps to extract codes whose 
    /// lengths are not necessarily divisible by 8
    /// from a byte array for further decoding
    /// </summary>
    public class ReadBuffer
    {
        private int intBuffer;
        public byte[] CompressedCodes { get; }
        private byte byteBuffer;
        private int byteBufferSize;
        private int curPos;
        private readonly int BYTE_BUFFER_CAPACITY = 8;

        public ReadBuffer(byte[] input)
        {
            CompressedCodes = input;
        }

        /// <summary>
        /// reads next code from compressed byte array
        /// </summary>
        /// <param name="currentCodeLength">bit length of the next code</param>
        /// <returns>next code from the array</returns>
        public int Read(int currentCodeLength)
        {
            intBuffer = 0;
            for (int i = currentCodeLength - 1; i >= 0; i--)
            {
                if (byteBufferSize == 0)
                {
                    byteBuffer = 0;
                    if (curPos == CompressedCodes.Length)
                        return -1;
                    byteBuffer = CompressedCodes[curPos];
                    curPos++;
                    byteBufferSize = BYTE_BUFFER_CAPACITY;
                }
                byte nextBit = (byte)((byteBuffer >> (byteBufferSize - 1)) % 2);
                intBuffer |= nextBit << i;
                byteBufferSize--;
            }
            return intBuffer;
        }
    }
}
