using System;

namespace WordGame
{
    public static class Helpers
    {
        public static string ScrambleWord(string word)
        {
            char[] chars = new char[word.Length];
            Random rand = new Random(10000);
            int index = 0;
            while (word.Length > 0)
            {
                int next = rand.Next(0, word.Length - 1);
                chars[index] = word[next];
                word = word.Substring(0, next) + word.Substring(next + 1);
                ++index;
            }
            return new String(chars);
        }

        public static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
