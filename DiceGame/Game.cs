namespace DiceGame;

public class Game()
{
	public Player Player { get; set; } = new();
	public Dealer Dealer { get; set; } = new();
	private bool isPlayerTurn = true;
	private bool playAgain = true;
	private int moneyInThePot;
	private bool shouldSkipLastText;

	public void GameLoop()
	{
		while (playAgain)
		{
			if (isPlayerTurn)
			{
				if (Player.WantsToRoll())
				{
					Player.RollDice();
					if (Player.Points > 21)
					{
						Console.WriteLine("Du gick över 21! Dealern har vunnit :(");
						return;
					}
				}
				else
				{
					isPlayerTurn = false;
				}
			}
			else
			{
				if (Dealer.ShouldRoll())
				{
					Dealer.RollDice();
					if (Dealer.Points > 21)
					{
						Console.WriteLine("Dealern gick över 21! Du har vunnit.");
						return;
					}
				}
				else
				{
					break;
				}
			}
		}

		DecideWinner();
	}

	public void DecideWinner()
	{
		Console.WriteLine("");

		if (Player.Points > Dealer.Points)
		{
			Console.WriteLine("Du vann eftersom att du kom närmare 21 än dealern!");
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
}
