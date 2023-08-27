using System;

namespace _1._1
{
    class Program
    {
        static int[] BubbleSort(int[] array)
        {
            int length = array.Length;
            for (var i = 0; i < length - 1; i++)
            {
                for (var j = i + 1; j < length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter the size of the array:");
            int length;
            try
            {
                length = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {

                Console.WriteLine("array's length must be non-negative number");
                return;
            }
            if (length < 0)
            {
                Console.WriteLine("array's length must be non-negative number");
                return;
            }
            var array = new int[length];
            Console.WriteLine("enter the elements of the array:");
            for (var i = 0; i < length; i++)
            {
                try
                {
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("array's elements must be numbers");
                    return;
                }
            }
            array = BubbleSort(array);
            
            Console.WriteLine("sorted array is:");
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
