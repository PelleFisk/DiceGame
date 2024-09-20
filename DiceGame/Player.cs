namespace DiceGame;

public class Player
{
	/// <summary>
	/// The points that the player currently has
	/// </summary>
	public int Points { get; private set; }
	
	/// <summary>
	/// The points that the player got when rolling the dice
	/// </summary>
	public int RollPoints { get; private set; }

	/// <summary>
	/// The money the player currently has
	/// </summary>
	public int Money { get; set; } = 10000;
	
	/// <summary>
	/// The amount of money the player choose to put in the pot
	/// </summary>
	public int CurrentBet { get; set; }
	
	/// <summary>
	/// If the player has choosen to stop
	/// </summary>
	public bool HasStopped { get; set; }
	
	private readonly Random rand = new();

	/// <summary>
	/// The logic for when the player plays their turn
	/// </summary>
	/// <returns>If the player chooses to end the round</returns>
	public void PlayTurn()
	{
		Console.WriteLine("Vill du slå eller stanna?");
		var choice = Console.ReadLine();
		
		if (choice == "stanna")
			HasStopped = true;
		if (choice == "slå")
		{
			var randNum = rand.Next(1, 7);
			RollPoints = randNum;
			Points += randNum;
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