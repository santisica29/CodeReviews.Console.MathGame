using MathGame2.Models;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace MathGame2
{
    internal class Helpers
    {
        internal static List<Game> games = new();
        internal static void PrintGames()
        {
            var gamesToPrint = games.Where(x => x.Date > new DateTime(2022, 08, 09)).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-------------------------");
            if (games.Count == 0)
            {
                Console.WriteLine("There are no previous games");
            }
            else
            {
                foreach (var game in gamesToPrint)
                {
                    string time = String.Format("{0:00}m:{1:00}s", game.TimeToCompletion.Minutes, game.TimeToCompletion.Seconds);

                    Console.WriteLine($"{game.Date} ({time}) - {game.Type} ({game.Difficulty}): {game.Score}pts");
                }
            }
            Console.WriteLine("-------------------------\n");
            if (games.Count > 0)
            {
                Console.WriteLine("Press 'd' to delete the list or any other key to go back to the main menu");
                if (Console.ReadLine().Trim().ToLower() == "d")
                {
                    games.Clear(); 
                    Console.Clear();
                    Console.WriteLine("List deleted");
                }
            }
            else
            {
                Console.WriteLine("Press any key to go back to the main menu");
            }
            Console.ReadLine();
        }

        internal static Difficulty GetDifficulty()
        {
            Console.WriteLine("Choose the level of difficulty: easy, medium, hard (e, m ,h)");
            string userDifficulty = Console.ReadLine().Trim().ToLower();

            while (string.IsNullOrEmpty(userDifficulty) || !Regex.IsMatch(userDifficulty, "^(e|m|h)$"))
            {
                Console.WriteLine("Wrong input try again");
                userDifficulty = Console.ReadLine();
            }

            if (userDifficulty == "e") return Difficulty.Easy;
            else if (userDifficulty == "h") return Difficulty.Hard;
            else return Difficulty.Medium;
        }
        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }

            return name;
        }
        internal static void AddToHistory(int score, GameType gameType, Difficulty difficulty, TimeSpan ts)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = score,
                Type = gameType,
                Difficulty = difficulty,
                TimeToCompletion = ts,
            });
        }
        internal static int[] GetDivisionNumbers()
        {
            Random random = new Random();

            var result = new int[2];
            var firstNumber = random.Next(1, 99);
            var secondNumber = random.Next(1, 99);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be a number. Try Again.");
                result = Console.ReadLine();
            }

            return result;
        }

        internal static int[] GetNumbers(Difficulty difficulty, GameType gameType = GameType.Addition)
        {
            if (gameType == GameType.Division)
            {
                return GetDivisionNumbers();
            }

            Random random = new Random();
            int num1;
            int num2;
            int[] numbers = new int[2];

            if (difficulty == Difficulty.Easy)
            {
                num1 = random.Next(1, 9);
                num2 = random.Next(1, 9);
            }
            else if (difficulty == Difficulty.Medium)
            {
                num1 = random.Next(1, 50);
                num2 = random.Next(1, 50);
            }
            else
            {
                num1 = random.Next(1, 100);
                num2 = random.Next(1, 100);
            }

            numbers[0] = num1;
            numbers[1] = num2;

            return numbers;
        }
    }
}
