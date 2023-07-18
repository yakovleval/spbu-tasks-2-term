using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
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
