using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysRotation
{
    public class ArrayRotation
    {

        // To rogate array left 
        // Let's assume that shift < length
        public static void ArrayRotateLeftDemo()
        {
            var a = Utilities.CreateSingleDimentionalArraySimple(5);
            Utilities.PrintSingleDimentionalArray(a, "    New array: ");

            var shift = 2;

            //var b = ArrayRotateLeft(a, shift);
            //var b = ArrayRotateLeftWithCopyToSecondArray(a, shift);
            var b = ArrayRotateLeftWithSmallTempArray(a, shift);
            

            Utilities.PrintSingleDimentionalArray(b, "Shifted array: ");
        }


        
        // this is relatively fast solution,
        // so it pass on hacker rank
        // https://www.hackerrank.com/challenges/array-left-rotation/problem
        // however, I don't like that we create new array
        public static int[] ArrayRotateLeftWithCopyToSecondArray(int[] a, int shift)
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

        // fast and beautiful method
        // reusing the same array
        // using small temp array to store replaced values when unavoidable
        // a - array, s - shift 
        public static int[] ArrayRotateLeftWithSmallTempArray(int[] a, int s)
        {
            var l = a.Length;
            var t = new int[s]; // temp array with size s = shift

            for (int i = 0; i < l; i++)
            {
                // save cells which will be replaced by shift
                if (i < s)
                    t[i] = a[i];

                if (i + s < l)
                    a[i] = a[i + s];
                else
                    a[i] = t[i + s - l];
            }

            return a;
        }

        // using the same same array, and only one temp variable
        // shifting everything several times by one
        // works, simple, but slow
        public static int[] ArrayRotateLeftCyclical(int[] a, int shift)
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


        // rotate right
        public static int[] ArrayRotateRightWithCreationOfANewArray(int[] a, int shift)
        {
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


        //array to list back and fourth conversion
        public static List<int> rotLeft(List<int> a, int d)
        {
            var r = ArrayRotateLeftCyclical(a.ToArray(), d);
            var l = new List<int>(r);
            return l;
        }

        //public static int[] ArrayRotateLeft2(int[] a, int d)
        //{
        //    var n = a.Length;

        //    int t = a[0];
        //    for (int i = 0; i < n; i++)
        //    {
        //        int j = (i + n - d) % n;
        //        a[i] = a[j];
        //    }

        //    return a;
        //}

        // TODO: non working method...
        //public static int[] ArrayRotateLeftShift(int[] a, int shift)
        //{
        //    var length = a.Length;
        //    int t;

        //    for (int i = 0; i < length; i++)
        //    {
        //        if (i + shift >= length)
        //        {
        //            t = a[i];
        //            a[i] = a[i + shift - length];
        //            a[i + shift - length] = t;
        //        }
        //        else
        //        {
        //            t = a[i];
        //            a[i] = a[i + shift];
        //            a[i + shift] = t;
        //        }
        //    }

        //    return a;
        //}




    }
}

