using System;
using System.Collections.Generic;
using System.Text;

namespace hw1task2
{
    internal class RotationsComparer : IComparer<int>
    {
        private string str;

        public RotationsComparer(string str)
        {
            this.str = str;
        }
        public int Compare(int x, int y)
        {
            for (var i = 0; i < str.Length; i++)
            {
                int result = str[(x + i) % str.Length].CompareTo(str[(y + i) % str.Length]);
                if (result != 0)
                    return result;
            }
            return 0;
        }
    }
    
    public class BWT
    {
        public static (string, int) Transform(string str)
        {
            var rotations = new int[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                rotations[i] = i;
            }
            Array.Sort(rotations, new RotationsComparer(str));
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                sb.Append(str[(rotations[i] + str.Length - 1) % str.Length]);
            }
            int index = Array.FindIndex(rotations, elem => elem == 0);
            return (sb.ToString(), index);
        }

        public static string Detransform((string, int) bwtResult)
        {
            string str = bwtResult.Item1;
            int index = bwtResult.Item2;
            var count = new int[1 << 16];
            for (var i = 0; i < str.Length; i++)
            {
                count[str[i]]++;
            }
            int sum = 0;
            for (var i = 0; i < count.Length; i++)
            {
                sum += count[i];
                count[i] = sum - count[i];
            }
            var reverseBwtVector = new int[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                reverseBwtVector[count[str[i]]] = i;
                count[str[i]]++;
            }
            var sb = new StringBuilder();
            int next = reverseBwtVector[index];
            for (var i = 0; i < str.Length; i++)
            {
                index = reverseBwtVector[index];
                sb.Append(str[index]);
            }
            return sb.ToString();
        }
    }
}
