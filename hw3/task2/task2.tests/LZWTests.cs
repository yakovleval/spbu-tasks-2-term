using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.tests
{
    [TestClass]
    public class LZWTests
    {
        private bool ByteArraysAreIdentical(byte[] left, byte[] right)
        {
            if (left.Length != right.Length)
                return false;
            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] != right[i])
                    return false;
            }
            return true;
        }
        [TestMethod]
        public void TestCompressAndDecompressEmptyByteArray()
        {
            byte[] array = Array.Empty<byte>();
            byte[] compressed = LZW.Compress(array);
            byte[] decompressed = LZW.Decompress(compressed);
            Assert.IsTrue(ByteArraysAreIdentical(array, decompressed));
        }
        [TestMethod]
        public void TestCompressAndDecompressArrayOfOneELem()
        {
            byte[] array = new byte[] { 0 };
            byte[] compressed = LZW.Compress(array);
            byte[] decompressed = LZW.Decompress(compressed);
            Assert.IsTrue(ByteArraysAreIdentical(array, decompressed));
        }
        [TestMethod]
        public void TestCompressAndDecompressArrayOfZeros()
        {
            byte[] array = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] compressed = LZW.Compress(array);
            byte[] decompressed = LZW.Decompress(compressed);
            Assert.IsTrue(ByteArraysAreIdentical(array, decompressed));
        }

        [TestMethod]
        public void TestCompressAndDecompressArbitraryArray()
        {
            byte[] array = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            byte[] compressed = LZW.Compress(array);
            byte[] decompressed = LZW.Decompress(compressed);
            Assert.IsTrue(ByteArraysAreIdentical(array, decompressed));
        }
        [TestMethod]
        public void TestCompressAndDecompressLargeArray()
        {
            byte[] array = File.ReadAllBytes("..\\..\\..\\TestFiles\\book-war-and-peace.txt");
            byte[] compressed = LZW.Compress(array);
            byte[] decompressed = LZW.Decompress(compressed);
            Assert.IsTrue(ByteArraysAreIdentical(array, decompressed));
        }
    }
}
