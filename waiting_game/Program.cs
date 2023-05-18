using System;
using System.Diagnostics;

namespace waiting_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int target = random.Next(2, 5);
            Console.WriteLine($"Your target time is {target} seconds");

            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine(" ---Press Enter to Begin--- ");
            Console.ReadLine();

            stopwatch.Start();

            Console.WriteLine($"...Press Enter again after {target} seconds");
            Console.ReadLine();

            stopwatch.Stop();

            TimeSpan elapsedTime = stopwatch.Elapsed;
            double seconds = elapsedTime.TotalSeconds;

            Console.WriteLine($"Elapsed time: {seconds:F3} seconds");

            if (seconds == target)
                Console.WriteLine("Unbelievable! Perfect timing!");
            else if (seconds < target)
                Console.WriteLine($"{target - seconds:F3} seconds too fast");
            else
                Console.WriteLine($"{seconds - target:F3} seconds too slow");

            Console.ReadKey();
        }
    }
}
