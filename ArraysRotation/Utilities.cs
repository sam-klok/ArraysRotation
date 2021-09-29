using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysRotation
{
    public class Utilities
    {
        public static int[] CreateSingleDimentionalArraySimple(int length = 5, int maxValue = 100)
        {
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
                array[i] = i;

            return array;
        }

        public static int[] CreateSingleDimentionalArray(int length = 5, int maxValue = 100)
        {
            int[] array = new int[length];

            var rand = new Random();
            for (int i = 0; i < length; i++)
                array[i] = rand.Next(maxValue);

            return array;
        }

        public static void PrintSingleDimentionalArray(int[] a, string initialMessage = "")
        {
            Console.Write(initialMessage);

            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + " ");

            Console.WriteLine();
        }
    }
}
