using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.Exceptions;

namespace task1.Tests
{
    public class IOTests
    {
        private static IEnumerable<TestCaseData> CorrectlyFormattedFiles
            => new TestCaseData[]
            {
                new TestCaseData(FileIO.ReadGraph("../../../TestFiles/Empty.txt"),
                    0, new List<Edge>()),
                new TestCaseData(FileIO.ReadGraph("../../../TestFiles/OneVertex.txt"),
                    1, new List<Edge>()),
                new TestCaseData(FileIO.ReadGraph("../../../TestFiles/TwoVertices.txt"),
                    2, new List<Edge>{new Edge(1, 2, 10)}),
                new TestCaseData(FileIO.ReadGraph("../../../TestFiles/ThreeVertices.txt"),
                    3, new List<Edge>
                    {
                        new Edge(1, 2, 10),
                        new Edge(1, 3, 5),
                        new Edge(2, 3, 1)
                    }),
            };
        [TestCaseSource(nameof(CorrectlyFormattedFiles))]
        public void TestCorrectlyFormattedFiles((int , List<Edge>) readGraph, 
            int actualVerticesNumber, 
            List<Edge> actualGraph)
        {
            var (verticesNumber, graph) = readGraph;
            Assert.That(verticesNumber, Is.EqualTo(actualVerticesNumber));
            Assert.IsTrue(Enumerable.SequenceEqual(graph.OrderBy(t => t), actualGraph.OrderBy(t => t)));
        }
        [Test]
        public void TestIncorrectFormat()
        {
            string path = "../../../TestFiles/IncorrectFormat.txt";
            Assert.Throws<FileFormatException>(() => FileIO.ReadGraph(path));
        }
        private static IEnumerable<TestCaseData> PrintGraphTestCases
            => new TestCaseData[]
            {
                new TestCaseData(FileIO.PrintGraph(1, new List<Edge>()), "1:\n"),
                new TestCaseData(FileIO.PrintGraph(2, new List<Edge>
                {
                    new Edge(1, 2, 10)
                }), "1: 2 (10)\n"),
                new TestCaseData(FileIO.PrintGraph(3, new List<Edge>
                {
                    new Edge(1, 2, 10),
                    new Edge(1, 3, 15)
                }), "1: 2 (10), 3 (15)\n"),
            };
        [TestCaseSource(nameof(PrintGraphTestCases))]
        public void TestPrintGraph(string actual, string expected)
        {
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
