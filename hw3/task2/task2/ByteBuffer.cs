using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class ByteBuffer
    {
        private byte byteBuffer;
        private FileStream output;
        private readonly int bufferCapacity = 8;
        private int curBufferSize;
        public ByteBuffer(FileStream output)
        {
            this.byteBuffer = 0;
            this.output = output; 
            this.curBufferSize = 0;
        }
        public void Write(int code, int currentCodeLength)
        {
            for (int i = currentCodeLength - 1; i >= 0; i--)
            {
                int bit = (code >> (i - 1)) % 2;
                byteBuffer |= (byte)(bit << (bufferCapacity - 1 - curBufferSize));
                curBufferSize++;
                if (curBufferSize == bufferCapacity)
                    Flush();
            }
        }
        public void Flush()
        {
            output.WriteByte(byteBuffer);
            byteBuffer = 0;
            curBufferSize = 0;
        }
    }
}
