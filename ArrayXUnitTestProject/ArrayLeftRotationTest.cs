using System;
using Xunit;
using ArraysRotation;
using System.Diagnostics;

namespace ArrayXUnitTestProject
{
    public class ArrayLeftRotationTest
    {
        [Fact]
        public void SpeedTest()
        {
            var a = Utilities.CreateSingleDimentionalArray(999999999, 9999999);

            var t1 = Time(() => ArrayRotation.ArrayRotateLeftWithTempArray(a, 15));
            var t2 = Time(() => ArrayRotation.ArrayRotateLeftWithCopyToSecondArray(a, 15));
            var t3 = Time(() => ArrayRotation.ArrayRotateLeftCyclical(a, 15));

            Assert.True(t1 < t2);
            Assert.True(t2 < t3);

            Debug.WriteLine("Time t1:" + t1);
            Debug.WriteLine("Time t2:" + t2);
            Debug.WriteLine("Time t3:" + t3);
        }


        private TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }
    }
}
