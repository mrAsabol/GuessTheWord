using System;

namespace WordGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbService = new DbService();
            var words = dbService.GetWords().ToArray();
         
            Helpers.PrintColorMessage(ConsoleColor.Cyan, "GUESS THE WORD GAME");

            int level = 1;
            int i = 0;

            while (true)
            {
                while (i < words.Length)
                {
                    string scrambled_Word = Helpers.ScrambleWord(words[i]);

                    if (level == words.Length)
                    {
                        Helpers.PrintColorMessage(ConsoleColor.DarkCyan, "FINAL LEVEL!");
                    }
                    else
                    {
                        Helpers.PrintColorMessage(ConsoleColor.DarkCyan, $"Level: {level}");
                    }
                    Console.WriteLine(scrambled_Word);
                    Console.Write("Answer: ");
                    string answer = Console.ReadLine();


                    if (answer == words[i])
                    {
                        Helpers.PrintColorMessage(ConsoleColor.Green, "CORRECT!");
                        level++;
                        i++;

                    }
                    else
                    {
                        Helpers.PrintColorMessage(ConsoleColor.Red, "WRONG!");
                        Helpers.PrintColorMessage(ConsoleColor.Red, "GAME OVER!");
                        Console.Write("Correct answer was: ");
                        Helpers.PrintColorMessage(ConsoleColor.Cyan, words[i]);
                        Console.WriteLine($"You've reached level: {level}");
                        Helpers.PrintColorMessage(ConsoleColor.DarkCyan, "Play Again? [Y or N]");

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

                Helpers.PrintColorMessage(ConsoleColor.Green, "Congratulation! You won. A true mastermind.");
                return;
            }
        }
    }
}

