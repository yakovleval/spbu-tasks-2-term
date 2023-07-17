using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class IntegerBuffer
    {
        private int intBuffer;
        private FileStream input;
        private byte byteBuffer;
        private int byteBufferSize;
        private readonly int BYTE_BUFFER_CAPACITY = 8;
        public IntegerBuffer(FileStream input)
        {
            intBuffer = 0;
            this.input = input;
            byteBuffer = 0;
            byteBufferSize = 0;
        }
        public int Read(int currentCodeLength)
        {
            intBuffer = 0;
            for (int i = currentCodeLength - 1; i >= 0; i--)
            {
                if (byteBufferSize == 0)
                {
                    byteBuffer = 0;
                    int readByte = input.ReadByte();
                    if (readByte == -1)
                        return -1;
                    byteBuffer = (byte)readByte;
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
