namespace Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    // Problem 2. IEnumerable extensions
    public static class IEnumerableExtentions
    {

        public static T Sum<T>(this IEnumerable<T> list)
        {
            T sum = (dynamic)0;

            foreach (var item in list)
            {
                sum += (dynamic)item;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> list)
        {
            T product = (dynamic)1;

            foreach (var item in list)
            {
                product *= (dynamic)item;
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> list)
        {
            var buffer = new List<T>();
            // I think casting to List is ok beacause of the fact that we already use IEnumerable interface who is List class ancestor
            // I want to use the indexer of the List
            // I see a some homeworks and they all where complex or using some other castings which I think limits the input data
            // I am against dynamic casting, but we will understand why we shouldn't use it everywhere in the futur
            // Now dynamic is working shokingly well :D
            buffer = (List<T>)list;
            T min = buffer[0];

            foreach (var item in buffer)
            {
                if (item < (dynamic)min)
                {
                    min = item;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> list)
        {
            var buffer = new List<T>();
            buffer = (List<T>)list;
            T max = buffer[0];

            foreach (var item in buffer)
            {
                if (item > (dynamic)max)
                {
                    max = item;
                }
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> list)
        {
            T sum = default(T);
            var buffer = (List<T>)list;
            int counter = 0;

            foreach (var item in list)
            {
                sum += (dynamic)item;
                counter++;
            }

            return sum/(dynamic)counter;
        }
    }
}
