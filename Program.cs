using System;

namespace WordGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbService = new DbService();

            var words = dbService.GetWords().ToArray();
         
            PrintColorMessage(ConsoleColor.Cyan, "GUESS THE WORD GAME");

            int level = 1;
            int i = 0;

            while (true)
            {
                while (i < words.Length)
                {
                    string scrambled_Word = ScrambleWord(words[i]);

                    if (level == words.Length)
                    {
                        PrintColorMessage(ConsoleColor.DarkCyan, "FINAL LEVEL!");
                    }
                    else
                    {
                        PrintColorMessage(ConsoleColor.DarkCyan, "Level: " + level);
                    }
                    Console.WriteLine(scrambled_Word);
                    Console.Write("Answer: ");
                    string answer = Console.ReadLine();


                    if (answer == words[i])
                    {
                        PrintColorMessage(ConsoleColor.Green, "CORRECT!");
                        level++;
                        i++;

                    }
                    else
                    {
                        PrintColorMessage(ConsoleColor.Red, "WRONG!");
                        PrintColorMessage(ConsoleColor.Red, "GAME OVER!");
                        Console.Write("Correct answer was: ");
                        PrintColorMessage(ConsoleColor.Cyan, words[i]);
                        Console.WriteLine("You've reached level: " + level);
                        PrintColorMessage(ConsoleColor.DarkCyan, "Play Again? [Y or N]");

                        //Play again?
                        string playAgain = Console.ReadLine().ToUpper();

                        if (playAgain == "Y")
                        {
                            i = 0;
                            level = 1;
                            continue;
                        }
                        else if (playAgain == "N")
                        {
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                PrintColorMessage(ConsoleColor.Green, "Congratulation! You won. A true mastermind.");
                return;

            }


        string ScrambleWord(string word)
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


            // Color
            void PrintColorMessage(ConsoleColor color, string message)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

    }
}

