using System.ComponentModel;

namespace task2.Tests
{
    public class Tests
    {
        private static readonly string testFiles = "../../../TestFiles/";

        [SetUp]
        public void Setup()
        {
        }
        private char[,] LoadMap(string pathToMap)
        {
            int maxLineLength = 0;
            string[] lines = File.ReadAllLines(pathToMap);
            for (int i = 0; i < lines.Length; i++)
            {
                maxLineLength = maxLineLength < lines[i].Length ? lines[i].Length : maxLineLength;
            }
            char [,] map = new char[lines.Length, maxLineLength];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }
            return map;
        }

        [TestCase("../../../TestFiles/TestMoveToFreeSpaceMap.txt", "../../../TestFiles/MapAfterLeftMove.txt", Game.Direction.Left)]
        [TestCase("../../../TestFiles/MapAfterLeftMove.txt", "../../../TestFiles/TestMoveToFreeSpaceMap.txt", Game.Direction.Right)]
        [TestCase("../../../TestFiles/TestMoveToFreeSpaceMap.txt", "../../../TestFiles/MapAfterUpMove.txt", Game.Direction.Up)]
        [TestCase("../../../TestFiles/MapAfterUpMove.txt", "../../../TestFiles/TestMoveToFreeSpaceMap.txt", Game.Direction.Down)]
        public void TestMoveToFreeSpace(string pathToMap, string pathToExpectedMap, Game.Direction dir)
        {
            Game game = new(pathToMap);
            char[,] expected = LoadMap(pathToExpectedMap);
            switch (dir)
            {
                case Game.Direction.Left:
                    game.OnLeft(this, new UpdateViewEventArgs(false));
                    break;
                case Game.Direction.Right:
                    game.OnRight(this, new UpdateViewEventArgs(false));
                    break;
                case Game.Direction.Up:
                    game.OnUp(this, new UpdateViewEventArgs(false));
                    break;
                case Game.Direction.Down:
                    game.OnDown(this, new UpdateViewEventArgs(false));
                    break;
            }
            Assert.AreEqual(expected, game.Map);
        }
        [TestCase(Game.Direction.Left)]
        [TestCase(Game.Direction.Right)]
        [TestCase(Game.Direction.Up)]
        [TestCase(Game.Direction.Down)]
        public void TestMoveToObstacle(Game.Direction dir)
        {
            Game game = new("../../../TestFiles/TestMoveToObstaclesMap.txt");
            char[,] expected = LoadMap("../../../TestFiles/TestMoveToObstaclesMap.txt");
            switch (dir)
            {
                case Game.Direction.Left:
                    game.OnLeft(this, new UpdateViewEventArgs(false));
                    break;
                case Game.Direction.Right:
                    game.OnRight(this, new UpdateViewEventArgs(false));
                    break;
                case Game.Direction.Up:
                    game.OnUp(this, new UpdateViewEventArgs(false));
                    break;
                case Game.Direction.Down:
                    game.OnDown(this, new UpdateViewEventArgs(false));
                    break;
            }
            Assert.AreEqual(expected, game.Map);
        }
    }
}