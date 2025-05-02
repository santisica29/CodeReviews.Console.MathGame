using MathGame2.Models;

namespace MathGame2
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu(string name)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {DateTime.Now}. This is your math's game. Let's get started.\n");
            Console.WriteLine("Press any key to see the menu");
            Console.ReadLine();

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play today?:
                V - View Previous Games
                A - Addition
                S - Subtraction
                M - Multiplication
                D - Division
                R - Random Mode
                Q - Quit
                ");
                Console.WriteLine("---------------------------");

                var userGameSelected = Console.ReadLine().Trim().ToLower();
                var difficulty = Difficulty.Easy;

                switch (userGameSelected)
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        difficulty = Helpers.GetDifficulty();
                        gameEngine.PlayGame(GameType.Addition, difficulty);
                        // gameEngine.AdditionGame("Addition selected");
                        break;
                    case "s":
                        difficulty = Helpers.GetDifficulty();
                        gameEngine.PlayGame(GameType.Subtraction, difficulty);
                        break;
                    case "m":
                        difficulty = Helpers.GetDifficulty();
                        gameEngine.PlayGame(GameType.Multiplication, difficulty);
                        break;
                    case "d":
                        difficulty = Helpers.GetDifficulty();
                        gameEngine.PlayGame(GameType.Division, difficulty);
                        break;
                    case "r":
                        gameEngine.PlayGame(GameType.Random, difficulty);
                        break;
                    case "q":
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine($"Incorrect input: {userGameSelected}");
                        Console.ReadLine();
                        break;
                }
            } while (isGameOn);
        }
    }
}
