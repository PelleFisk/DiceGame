namespace DiceGame;

public class Dealer
{
	public int Points { get; set; }
	public int RollPoints { get; set; }
	private readonly Random rand = new();

	public void PlayTurn()
	{
		if (Points <= 17)
		{
			var randNum = rand.Next(1, 7);
			Points += randNum;
			RollPoints = randNum;
		}
	}

	public bool HasTwentyOnePoints()
	{
		return Points == 21;
	}

	public bool HasOverTwentyOnePoints()
	{
		return Points > 21;
	}
}