namespace DiceGame;

public class Player
{
	/// <summary>
	/// The points that the player currently has
	/// </summary>
	public int Points { get; private set; }

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
	public void RollDice()
	{
		Console.WriteLine("Vill du slå eller stanna?");
		var choice = Console.ReadLine();
		var randNum = rand.Next(1, 7);
		Points += randNum;
	}

	public bool WantsToRoll()
	{
		Console.WriteLine("Vill du slå tärningen eller stanna? (slå/stanna)");
		var choice = Console.ReadLine();
		return choice == "slå";
	}

	public void Reset()
	{
		Points = 0;
	}
}
