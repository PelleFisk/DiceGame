namespace DiceGame;

public class Dealer()
{
	public int Points { get; set; }
	private readonly Random rand = new();

	public bool ShouldRoll()
	{
		return Points < 17;
	}

	public void DrawCard()
	{
		var card = rand.Next(1, 14);
		var cardValue = card > 10 ? 10 : card;
		Points += cardValue;
		Console.WriteLine($"Dealern drog ett kort med värdet: {cardValue}, dealerns totala poäng är: {Points}");
	}
}
