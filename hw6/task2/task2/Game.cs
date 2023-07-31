using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Game
    {
        private enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }
        private struct Coords
        {
            public int x;
            public int y;
        }
        private char[,] map;
        private Coords charCords;
        private readonly char obstacle = '#';
        private readonly char freeSpace = ' ';
        private readonly char character = '@';
        public Game(string pathToMap)
        {
            int maxLineLength = 0;
            string[] lines = File.ReadAllLines(pathToMap);
            for (int i = 0; i < lines.Length; i++)
            {
                maxLineLength = maxLineLength < lines[i].Length ? lines[i].Length : maxLineLength;
            }
            map = new char[lines.Length, maxLineLength];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] != obstacle && lines[i][j] != freeSpace &&
                        lines[i][j] != character)
                        throw new FormatException("map format is incorrect");
                    map[i, j] = lines[i][j];
                    if (lines[i][j] == character)
                    {
                        charCords.x = i;
                        charCords.y = j;
                    }
                }
            }
            PrintMap();
        }

        private void PrintMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        private bool CanMove(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    return charCords.y > 0 && 
                        map[charCords.x, charCords.y - 1] == freeSpace;
                case Direction.Right:
                    return charCords.y < map.GetLength(1) - 1 && 
                        map[charCords.x, charCords.y + 1] == freeSpace;
                case Direction.Up:
                    return charCords.x > 0 &&
                        map[charCords.x - 1, charCords.y] == freeSpace;
                default:
                    return charCords.x < map.GetLength(0) &&
                        map[charCords.x + 1, charCords.y] == freeSpace;
            }
        }
        private void Move(Direction dir)
        {
            if (!CanMove(dir))
                return;
            Console.SetCursorPosition(charCords.y, charCords.x);
            map[charCords.x, charCords.y] = freeSpace;
            Console.Write(freeSpace);
            switch (dir)
            {
                case Direction.Left:
                    charCords.y--;
                    break;
                case Direction.Right:
                    charCords.y++;
                    break;
                case Direction.Up:
                    charCords.x--;
                    break;
                default:
                    charCords.x++;
                    break;
            }
            Console.SetCursorPosition(charCords.y, charCords.x);
            map[charCords.x, charCords.y] = character;
            Console.Write(character);
        }
        public void OnLeft(object sender, EventArgs args)
        {
            Move(Direction.Left);
        }
        public void OnRight(object sender, EventArgs args)
        {
            Move(Direction.Right);
        }
        public void OnUp(object sender, EventArgs args)
        {
            Move(Direction.Up);
        }
        public void OnDown(object sender, EventArgs args)
        {
            Move(Direction.Down);
        }
    }
}
