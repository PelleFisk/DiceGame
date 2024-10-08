﻿namespace DiceGame;

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
	public int Bet { get; set; }

	private readonly Random rand = new();

	/// <summary>
	/// The logic for when the player draws a card
	/// </summary>
	public void DrawCard()
	{
		var card = rand.Next(1, 14);
		var cardValue = card > 10 ? 10 : card;
		Points += cardValue;
		Console.WriteLine($"Du drog ett kort med värdet: {cardValue}, du har nu {Points} poäng");
	}

	/// <summary>
	/// Asks the player if he wants to draw a card
	/// </summary>
	/// <returns>If the player chooses to stop</returns>
	public bool WantsToRoll()
	{
		Console.WriteLine("Vill du dra ett kort eller stanna? (dra/stanna)");
		var choice = Console.ReadLine();
		return choice == "dra";
	}

	/// <summary>
	/// Asks for a bet from the player
	/// </summary>
	/// <exception cref="Exception">If the user writes something that can not be parsed to an int</exception>
	public void PlaceBet()
	{
		Console.WriteLine($"Du har just nu: {Money} pengar. Hur mycket vill du satsa?");
		Bet = int.TryParse(Console.ReadLine(), out var amount) ? amount : throw new Exception("Can't parse the given string");

		if (Bet > Money || Bet < 0)
		{
			Console.WriteLine("Ogiltig satstning. Försök igen!");
			Bet = int.TryParse(Console.ReadLine(), out amount) ? amount : throw new Exception("Can't parse the given string");
		}

		Money -= Bet;
	}

	/// <summary>
	/// The logic for when the user wins the game and there for wins the bet
	/// </summary>
	public void WinBet()
	{
		Money += Bet * 2;
	}

	/// <summary>
	/// Resets the player points and the bet
	/// </summary>
	public void Reset()
	{
		Points = 0;
		Bet = 0;
	}
}
