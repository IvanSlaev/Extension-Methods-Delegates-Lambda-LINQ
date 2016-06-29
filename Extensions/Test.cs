namespace Extensions
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public static class Test
    {
        static void Main(string[] args)
        {
            var text = new StringBuilder();
            text.Append("I am here for wirking");

            var newText = text.Substring(5, 4);
            Console.WriteLine(newText + 
                "\nThat was the result of Substring Extention Method\n...............................................");

            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            //list.Add(0);


            var sum = list.Sum<int>();
            Console.WriteLine(sum + 
                "\nThat was the result of Sum IEnumerable Extention Method\n...............................................");

            var product = list.Product<int>();
            Console.WriteLine(product +
                "\nThat was the result of Product IEnumerable Extention Method\n...............................................");

            var min = list.Min<int>();
            Console.WriteLine(min +
                "\nThat was the result of Min IEnumerable Extention Method\n...............................................");

            var max = list.Max<int>();
            Console.WriteLine(max +
                "\nThat was the result of Max IEnumerable Extention Method\n...............................................");

            var avr = list.Average<int>();
            Console.WriteLine(avr +
                "\nThat was the result of Average IEnumerable Extention Method\n...............................................");
            Console.WriteLine();
            Console.WriteLine("........................................................................");
            Console.WriteLine();
        }
    }
}
