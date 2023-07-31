using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Game
    {
        public enum Direction
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
        public char[,] Map { get; private set; }
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
            Map = new char[lines.Length, maxLineLength];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] != obstacle && lines[i][j] != freeSpace &&
                        lines[i][j] != character)
                        throw new FormatException("map format is incorrect");
                    Map[i, j] = lines[i][j];
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
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.Write(Map[i, j]);
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
                        Map[charCords.x, charCords.y - 1] == freeSpace;
                case Direction.Right:
                    return charCords.y < Map.GetLength(1) - 1 && 
                        Map[charCords.x, charCords.y + 1] == freeSpace;
                case Direction.Up:
                    return charCords.x > 0 &&
                        Map[charCords.x - 1, charCords.y] == freeSpace;
                default:
                    return charCords.x < Map.GetLength(0) &&
                        Map[charCords.x + 1, charCords.y] == freeSpace;
            }
        }
        private void Move(Direction dir, bool updateView)
        {
            if (!CanMove(dir))
                return;
            if (updateView)
            {
                Console.SetCursorPosition(charCords.y, charCords.x);
                Console.Write(freeSpace);
            }
            Map[charCords.x, charCords.y] = freeSpace;
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
            Map[charCords.x, charCords.y] = character;
            if (updateView)
            {
                Console.SetCursorPosition(charCords.y, charCords.x);
                Console.Write(character);
            }
        }
        public void OnLeft(object sender, UpdateViewEventArgs args)
        {
            Move(Direction.Left, args.UpdateView);
        }
        public void OnRight(object sender, UpdateViewEventArgs args)
        {
            Move(Direction.Right, args.UpdateView);
        }
        public void OnUp(object sender, UpdateViewEventArgs args)
        {
            Move(Direction.Up, args.UpdateView);
        }
        public void OnDown(object sender, UpdateViewEventArgs args)
        {
            Move(Direction.Down, args.UpdateView);
        }
    }
}
