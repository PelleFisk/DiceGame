namespace DiceGame;

public class Dealer()
{
	public int Points { get; set; }
	private readonly Random rand = new();
	public bool HasStopped { get; set; }

	public bool ShouldRoll()
	{
		return Points < 17;
	}

	public void RollDice()
	{
		var randNum = rand.Next(1, 7);
		Points += randNum;
		Console.WriteLine($"Dealern slog: {randNum}, dealerns totala poäng är: {Points}");
	}
}
