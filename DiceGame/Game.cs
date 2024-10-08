﻿namespace DiceGame;

public class Game(Player player)
{
	/// <summary>
	/// The player
	/// </summary>
	public Player Player { get; } = player;
	
	/// <summary>
	/// The dealer
	/// </summary>
	public Dealer Dealer { get; } = new();
	private bool isPlayerTurn = true;
	private bool playerStopped;
	private bool dealerStopped;

	/// <summary>
	/// The loop where all the game logic happens
	/// </summary>
	public void GameLoop()
	{
		Player.PlaceBet();

		while (!playerStopped || !dealerStopped)
		{
			if (isPlayerTurn && !playerStopped)
			{
				if (Player.WantsToRoll())
				{
					Player.DrawCard();
					if (Player.Points > 21)
					{
						Console.WriteLine("Du gick över 21! Dealern har vunnit :(");
						return;
					}
				}
				else
				{
					playerStopped = true;
				}
			}
			else if (!dealerStopped)
			{
				if (Dealer.ShouldRoll())
				{
					Dealer.DrawCard();
					if (Dealer.Points > 21)
					{
						Console.WriteLine("Dealern gick över 21! Du har vunnit.");
						Player.WinBet();
						return;
					}
				}
				else
				{
					dealerStopped = true;
				}
			}

			isPlayerTurn = !isPlayerTurn;
		}

		DecideWinner();
	}

	/// <summary>
	/// The method that decides the winner between the player and dealer
	/// </summary>
	public void DecideWinner()
	{
		Console.WriteLine($"Dina poäng: {Player.Points}");
		Console.WriteLine($"Dealerns poäng: {Dealer.Points}");

		if (Player.Points > Dealer.Points)
		{
			Console.WriteLine("Du vann eftersom att du kom närmare 21 än dealern!");
			Player.WinBet();
		}
		else if (Dealer.Points > Player.Points)
		{
			Console.WriteLine("Du förlorade eftersom att dealern kom närmare 21 än dig :(");
		}
		else
		{
			Console.WriteLine("Dealern vann eftersom att du och dealern fick samma poäng :(");
		}
	}

	/// <summary>
	/// Resets the game
	/// </summary>
	public void ResetGame()
	{
		Player.Reset();
	}
}
