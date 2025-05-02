namespace MathGame2.Models;

internal class Game
{
    internal int Score { get; set; }
    internal DateTime Date { get; set; }
    internal GameType Type { get; set; }
    internal Difficulty Difficulty { get; set; }
    internal TimeSpan TimeToCompletion { get; set; }

}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}

internal enum Difficulty
{
    Easy,
    Medium,
    Hard
}