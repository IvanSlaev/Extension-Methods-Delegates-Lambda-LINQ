namespace Timer
{
    using System;
    using System.Diagnostics;


    // Problem 7. Timer
    public class Timer
    {
        private readonly int seconds;
        private int count;
        public delegate void PrintSomething();

        public Timer(int seconds, int count)
        {
            this.seconds = seconds;
            this.count = count;
        }

        public void InvokeDelegate()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var myDelegate = new PrintSomething(EverySecond);
            int i = 0;

            while (true)
            {
                if (i == count)
                {
                    break;
                }

                if (stopwatch.Elapsed.Seconds != this.seconds)
                {
                    continue;
                }

                i++;
                myDelegate();
                stopwatch.Restart();
            }
        }

        private static void EverySecond()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
