using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleBy7And3
{
    class DivisibleBy7And3
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 210, 1, 2, 3, 4, 5, 6, 7, 8, 9 , 21};

            foreach (var number in BuildIn(array))
            {
                Console.WriteLine(number);
            }
        }

        public static int[] BuildIn(int[] array)
        {
            var newArr = array
                .Where(x => x % 3 == 0 && x % 7 == 0)
                .ToArray();

            return newArr;
        }
    }
}
