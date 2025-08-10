using System;

namespace rgn
{
    public static class Maths
    {
        /// <summary>
        /// convert radians to degrees
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>converted angle</returns>
        public static double RadToDeg(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        /// <summary>
        /// Gets random item from array.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="array">Array.</param>
        public static string RandomItem(string[] array)
        {
            var rand = new Random();
            var max = array.Length;
            var index = rand.Next(max);

            var item = array[index];
            return item;
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }
            return value;
        }
    }
}