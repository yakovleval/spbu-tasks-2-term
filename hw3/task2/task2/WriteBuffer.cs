namespace Task2
{
    /// <summary>
    /// this class helps to write codes 
    /// whose lengths are not necessarily divisible by 8
    /// to a byte array for further writing to a file
    /// </summary>
    public class WriteBuffer
    {
        private byte byteBuffer;
        private readonly int BUFFER_CAPACITY = 8;
        private int curBufferSize;
        public List<byte> CompressedBytes { get; }
        public WriteBuffer()
        {
            this.byteBuffer = 0;
            this.curBufferSize = 0;
            CompressedBytes = new();
        }

        /// <summary>
        /// writes code to a byte array
        /// </summary>
        /// <param name="code">code to write</param>
        /// <param name="currentCodeLength">bit length of the code</param>
        public void Write(int code, int currentCodeLength)
        {
            for (int i = currentCodeLength - 1; i >= 0; i--)
            {
                int bit = (code >> i) % 2;
                byteBuffer |= (byte)(bit << (BUFFER_CAPACITY - 1 - curBufferSize));
                curBufferSize++;
                if (curBufferSize == BUFFER_CAPACITY)
                    Flush();
            }
        }

        /// <summary>
        /// writes the remaning bits in the buffer to the array
        /// </summary>
        public void Flush()
        {
            if (curBufferSize != 0)
            {
                CompressedBytes.Add(byteBuffer);
                byteBuffer = 0;
                curBufferSize = 0;
            }
        }
    }
}
