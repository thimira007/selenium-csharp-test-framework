using System;

namespace SeleniumCsharp.Utils
{
    public static class Helpers
    {
        private static readonly Random random = new Random();

        public static int GetRandomIndex(int start, int end)
        {
            if (start >= end)
                throw new ArgumentException("Start value must be less than the end value.");

            int randomIndex = random.Next(start, end);

            // Log the generated random number
            Console.WriteLine($"Generated Random Index: {randomIndex}");
            return randomIndex;
        }
    }
}
