using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.tests
{
    [TestClass]
    public class BuffersTests
    {
        [TestMethod]
        public void TestWriteAndReadArbitraryCodeSequence()
        {
            int numberOfCodes = 10;
            WriteBuffer writeBuf = new();
            for (int i = 0, codeLength = 8; i < numberOfCodes; i++, codeLength++)
            {
                writeBuf.Write(i, codeLength);
            }
            writeBuf.Flush();
            var compressedBytes = writeBuf.CompressedBytes.ToArray();
            ReadBuffer readBuf = new(compressedBytes);
            for (int i = 0, codeLength = 8; i < numberOfCodes; i++, codeLength++)
            {
                int code = readBuf.Read(codeLength);
                Assert.AreEqual(i, code);
            }
        }
        [TestMethod]
        public void TestReadEmpty()
        {
            ReadBuffer readBuf = new(Array.Empty<byte>());
            int codeLength = 8;
            int code = readBuf.Read(codeLength);
            Assert.AreEqual(-1, code);
        }
    }
}
