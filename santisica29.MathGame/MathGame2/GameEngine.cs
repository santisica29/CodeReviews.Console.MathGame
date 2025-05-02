using MathGame2.Models;
using System.Diagnostics;
using System.Security.AccessControl;

namespace MathGame2
{
    internal class GameEngine
    {
        internal void PlayGame(GameType gameType, Difficulty difficulty)
        {
            if (gameType == GameType.Random)
            {
                PlayRandom();
                return;
            }
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine($"{difficulty.ToString().ToUpper()} MODE\n");

                bool gameWon = PlayRound(gameType, difficulty);

                if (gameWon)
                {
                    score++;
                    Console.WriteLine("You are correct");
                }
                else
                {
                    Console.WriteLine("You are wrong");
                }

                Console.ReadLine();
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            Helpers.AddToHistory(score, gameType, difficulty, ts);
            Console.WriteLine($"Game over. Final score: {score}");
            Console.ReadLine();
        }

        internal void PlayRandom()
        {
            GameType[] gametypeOptions = [GameType.Addition, GameType.Subtraction, GameType.Multiplication, GameType.Division];
            Difficulty[] difficultyOptions = [Difficulty.Hard, Difficulty.Medium, Difficulty.Easy];

            int score = 0;

            Random random = new Random();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine("RANDOM MODE\n");

                int randomNumberGT = random.Next(0, 5);
                int randomNumberD = random.Next(0, 3);

                GameType gameType = gametypeOptions[randomNumberGT];
                Difficulty difficulty = difficultyOptions[randomNumberD];

                bool gameWon = PlayRound(gameType, difficulty); 

                if (gameWon)
                {
                    score++;
                    Console.WriteLine("You are correct");
                }
                else
                {
                    Console.WriteLine("You are wrong");
                }
                Console.ReadLine();
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Helpers.AddToHistory(score, GameType.Random, Difficulty.Medium, ts);
            Console.WriteLine($"Game over. Final score: {score}");
            Console.ReadLine();
        }

        internal bool PlayRound(GameType gameType, Difficulty difficulty)
        {
            int[] numbers = new int[2];
            int num1 = 0;
            int num2 = 0;

            numbers = Helpers.GetNumbers(difficulty, gameType);

            num1 = numbers[0];
            num2 = numbers[1];

            string guess = "";
            int result = 0;

            switch (gameType)
            {
                case GameType.Addition:
                    result = num1 + num2;
                    Console.WriteLine($"{num1} + {num2}");
                    break;
                case GameType.Subtraction:
                    result = num1 - num2;
                    Console.WriteLine($"{num1} - {num2}");
                    break;
                case GameType.Multiplication:
                    result = num1 * num2;
                    Console.WriteLine($"{num1} * {num2}");
                    break;
                case GameType.Division:
                    result = num1 / num2;
                    Console.WriteLine($"{num1} / {num2}");
                    break;
            }
            guess = Console.ReadLine();
            guess = Helpers.ValidateResult(guess);

            if (int.Parse(guess) == result) return true;
            else return false;
        }
        //internal void AdditionGame(string message)
        //{
        //    Console.WriteLine(message);
        //    Random random = new Random();

        //    int firstNumber;
        //    int secondNumber;
        //    int score = 0;

        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.Clear();
        //        firstNumber = random.Next(1, 9);
        //        secondNumber = random.Next(1, 9);

        //        Console.WriteLine($"{firstNumber} + {secondNumber}");
        //        var result = Console.ReadLine();

        //        result = Helpers.ValidateResult(result);

        //        if (int.Parse(result) == (firstNumber + secondNumber))
        //        {
        //            Console.WriteLine("Your answer was correct");
        //            score++;
        //        }
        //        else
        //        {
        //            Console.WriteLine("You are wrong");
        //        }
        //        Console.ReadLine();
        //    }
        //    Helpers.AddToHistory(score, GameType.Addition);
        //    Console.WriteLine($"Game over. Final score: {score}");
        //    Console.ReadLine();
        //}
        //internal void SubstractionGame(string message)
        //{
        //    Console.WriteLine(message);
        //    Random random = new Random();

        //    int firstNumber;
        //    int secondNumber;
        //    int score = 0;

        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.Clear();
        //        firstNumber = random.Next(1, 9);
        //        secondNumber = random.Next(1, 9);

        //        Console.WriteLine($"{firstNumber} - {secondNumber}");
        //        var result = Console.ReadLine();

        //        result = Helpers.ValidateResult(result);

        //        if (int.Parse(result) == (firstNumber - secondNumber))
        //        {
        //            Console.WriteLine("Your answer was correct");
        //            score++;
        //        }
        //        else
        //        {
        //            Console.WriteLine("You are wrong");
        //        }
        //        Console.ReadLine();
        //    }
        //    Helpers.AddToHistory(score, GameType.Subtraction);
        //    Console.WriteLine($"Game over. Final score: {score}");
        //    Console.ReadLine();
        //}
        //internal void MultiplicationGame(string message)
        //{
        //    Random random = new Random();
        //    Console.WriteLine(message);

        //    int firstNumber;
        //    int secondNumber;
        //    int score = 0;

        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.Clear();
        //        firstNumber = random.Next(1, 9);
        //        secondNumber = random.Next(1, 9);

        //        Console.WriteLine($"{firstNumber} * {secondNumber}");
        //        var result = Console.ReadLine();

        //        result = Helpers.ValidateResult(result);

        //        if (int.Parse(result) == (firstNumber * secondNumber))
        //        {
        //            Console.WriteLine("Your answer was correct");
        //            score++;
        //        }
        //        else
        //        {
        //            Console.WriteLine("You are wrong");
        //        }
        //        Console.ReadLine();
        //    }
        //    Helpers.AddToHistory(score, GameType.Multiplication);

        //    Console.WriteLine($"Game over. Final score: {score}");
        //    Console.ReadLine();
        //}
        //internal void DivisionGame(string message)
        //{
        //    int score = 0;

        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.Clear();
        //        var divisionNumbers = Helpers.GetDivisionNumbers();

        //        var firstNumber = divisionNumbers[0];
        //        var secondNumber = divisionNumbers[1];


        //        Console.WriteLine($"{firstNumber} / {secondNumber}");
        //        var result = Console.ReadLine();

        //        result = Helpers.ValidateResult(result);

        //        if (int.Parse(result) == (firstNumber / secondNumber))
        //        {
        //            Console.WriteLine("Your answer was correct");
        //            score++;
        //        }
        //        else
        //        {
        //            Console.WriteLine("You are wrong");
        //        }
        //        Console.ReadLine();
        //    }
        //    Helpers.AddToHistory(score, GameType.Division);

        //    Console.WriteLine($"Game over. Final score: {score}");
        //    Console.ReadLine();
        //}
    }
}
