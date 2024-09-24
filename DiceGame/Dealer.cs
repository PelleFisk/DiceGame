namespace DiceGame;

public class Dealer()
{
	/// <summary>
	/// The total points the dealer has
	/// </summary>
	public int Points { get; set; }
	private readonly Random rand = new();

	/// <summary>
	/// Checks if the total points of the dealer is less than 17
	/// </summary>
	/// <returns>If the dealer can roll</returns>
	public bool ShouldRoll()
	{
		return Points < 17;
	}

	/// <summary>
	/// The logic for when the dealer draws a card
	/// </summary>
	public void DrawCard()
	{
		var card = rand.Next(1, 14);
		var cardValue = card > 10 ? 10 : card;
		Points += cardValue;
		Console.WriteLine($"Dealern drog ett kort med värdet: {cardValue}, dealerns totala poäng är: {Points}");
	}
}
