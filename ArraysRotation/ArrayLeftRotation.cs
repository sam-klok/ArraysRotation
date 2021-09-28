using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysRotation
{
    public class ArrayLeftRotation
    {
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

            //foreach (var item in a)
            //    Console.Write(item + " ");

            Console.WriteLine();
        }


        // To rogate array left 
        // Let's assume that shift < length
        public static void ArrayRotateLeftDemo()
        {
            var a = CreateSingleDimentionalArray(5);
            PrintSingleDimentionalArray(a, "    New array: ");

            var shift = 2;

            //var b = ArrayRotateLeft(a, shift);
            var b = ArrayRotateLeft(a, shift);
            //var b = ArrayRotateLeftWithCreationOfANewArray(a, shift);

            PrintSingleDimentionalArray(b, "Shifted array: ");
        }


        
        public static int[] ArrayRotateRightWithCreationOfANewArray(int[] a, int shift) {
            var length = a.Length;
            var b = new int[length];   // this method create copy of the Array, which is usually frown upon

            for (int i = 0; i < length; i++)
            {
                int j = i + shift;  // "+" shift right

                if (j >= length)
                    j -= length;

                b[j] = a[i];
            }

            return b;
        }


        // this is relatively fast solution,
        // so it pass on hacker rank
        // https://www.hackerrank.com/challenges/array-left-rotation/problem
        // however, I don't like that we create new array
        public static int[] ArrayRotateLeftWithCreationOfANewArray(int[] a, int shift)
        {
            var length = a.Length;
            var b = new int[length]; // this method create copy of the Array, which is usually frown upon

            for (int i = 0; i < length; i++)
            {
                int j = i - shift;  // "-" shift left

                if (j < 0)
                    j += length;

                b[j] = a[i];
            }

            return b;
        }


        // same array, shifting everything several times by one
        // works
        public static int[] ArrayRotateLeft(int[] a, int shift)
        {
            var length = a.Length;

            for (int j = 0; j < shift; j++)
            {
                int t = a[0];
                for (int i = 0; i < length; i++)
                {
                    if (i == length - 1)
                        a[i] = t;
                    else
                        a[i] = a[i + 1];
                }
            }

            return a;
        }

        public static int[] ArrayRotateLeft2(int[] a, int d)
        {
            var n = a.Length;

            int t = a[0];
            for (int i = 0; i < n; i++)
            {
                int j = (i + n - d) % n;
                a[i] = a[j];
            }

            return a;
        }


        // TODO: non working method...
        public static int[] ArrayRotateLeftShift(int[] a, int shift)
        {
            var length = a.Length;
            int t;

            for (int i = 0; i < length; i++)
            {
                if (i + shift >= length)
                {
                    t = a[i];
                    a[i] = a[i + shift - length];
                    a[i + shift - length] = t;
                }
                else
                {
                    t = a[i];
                    a[i] = a[i + shift];
                    a[i + shift] = t;
                }
            }

            return a;
        }


        //some array to list back and fourth conversion
        public static List<int> rotLeft(List<int> a, int d)
        {
            
            var r = ArrayRotateLeft(a.ToArray(), d);
            var l = new List<int>(r);
            return l;
        }

    }
}

