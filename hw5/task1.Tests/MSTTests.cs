using Task1.Exceptions;
namespace Task1.Tests

{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        private static IEnumerable<TestCaseData> CorrectGraphs
            => new TestCaseData[]
            {
                new TestCaseData(new List<Edge>{}, 1, 0),
                new TestCaseData(new List<Edge>{new Edge(1, 2, 42)}, 2, 42),
                new TestCaseData(new List<Edge>
                {
                    new Edge(1, 2, 42),
                    new Edge(1, 3, 42),
                }, 3, 84),
                new TestCaseData(new List<Edge>
                {
                    new Edge(1, 2, 10),
                    new Edge(1, 3, 5),
                    new Edge(2, 3, 1)
                }, 3, 15),
                new TestCaseData(new List<Edge>
                {
                    new Edge(1, 2, 1),
                    new Edge(2, 3, 1),
                    new Edge(3, 4, 1),
                    new Edge(1, 4, 2)
                }, 4, 4)
            };

        [TestCaseSource(nameof(CorrectGraphs))]
        public void TestBuildsTreeOfMaximumWeight(List<Edge> graph, int verticesNumber, int actualMSTWeight)
        {
            var mst = MST.BuildMST(verticesNumber, graph);
            Assert.That(mst.Count, Is.EqualTo(verticesNumber - 1));
            int weightsSum = 0;
            foreach (var edge in mst)
                weightsSum += edge.Weight;
            Assert.That(weightsSum, Is.EqualTo(actualMSTWeight));
        }

        [Test]
        public void TestEmptyGraph()
        {
            List<Edge> graph = new();
            Assert.Throws<EmptyGraphException>(() => MST.BuildMST(0, graph));
        }

        private static IEnumerable<TestCaseData> DisconnectedGraphs
            => new TestCaseData[]
            {
                new TestCaseData(new List<Edge>(), 2),
                new TestCaseData(new List<Edge>(), 3),
                new TestCaseData(new List<Edge>{new Edge(1, 2, 1)}, 3),
                new TestCaseData(new List<Edge>{new Edge(1, 2, 1), new Edge(3, 4, 2)}, 4)
            };

        [TestCaseSource(nameof(DisconnectedGraphs))]
        public void TestDisconnectedGraphs(List<Edge> graph, int verticesNumber)
        {
            Assert.Throws<GraphNotConnectedException>(() => MST.BuildMST(verticesNumber, graph));
        }
    }
}