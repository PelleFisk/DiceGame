namespace DiceGame;

public class Game(Player player, Dealer dealer)
{
	public Player Player { get; set; } = player;
	public Dealer Dealer { get; set; } = dealer;
	private bool isPlayerTurn = true;
	private bool playAgain = true;
	private int moneyInThePot;
	private bool shouldSkipLastText;
	private bool done;

	public void GameLoop()
	{
		while (playAgain)
		{
			if (done)
			{
				if (PlayAgain())
					done = false;
				else
					return;
			}
			
			if (Player.HasStopped && Dealer.HasStopped)
			{
				DecideWinner();
				continue;
			}
			
			if (isPlayerTurn && !Player.HasStopped)
			{
				Player.PlayTurn();
				Dealer.PlayTurn();
				
				if (Player.HasStopped)
					continue;
				
				if (BaseCasesAreTrue())
				{
					DecideWinner();
					continue;
				}
				
				Console.WriteLine($"Du slog: {Player.RollPoints}, din totala poäng är: {Player.Points}");
				Console.WriteLine($"Dealern slog: {Dealer.RollPoints}, dealerns totala poäng är: {Dealer.Points}");
			}
			else
			{
				if (Player.HasStopped && Player.Points < Dealer.Points)
				{
					Dealer.HasStopped = true;
					continue;
				}

				if (Dealer.Points > 17)
				{
					Dealer.HasStopped = true;
					continue;
				}
				
				if (!Player.HasStopped)
				{
					Dealer.PlayTurn();
					Console.WriteLine($"Dealern slog: {Dealer.RollPoints}, dealerns totala poäng är: {Dealer.Points}");
					
					if (BaseCasesAreTrue())
					{
						DecideWinner();
						continue;
					}

					Player.PlayTurn();
					
					if (BaseCasesAreTrue())
					{
						DecideWinner();
						continue;
					}

					if (Player.HasStopped)
					{
						isPlayerTurn = false;
						continue;
					}

					Console.WriteLine($"Du slog: {Player.RollPoints}, din totala poäng är: {Player.Points}");
					Console.WriteLine($"Dealerns poäng är: {Dealer.Points}");
				}
				else if (Player.HasStopped && !done)
				{
					Dealer.PlayTurn();
					Console.WriteLine($"Dealern slog: {Dealer.RollPoints}, dealerns totala poäng är: {Dealer.Points}");
				}
			}

			isPlayerTurn = !isPlayerTurn;
		}
	}

	public bool BaseCasesAreTrue()
	{
		return Player.HasTwentyOnePoints() || Player.HasOverTwentyOnePoints() || Dealer.HasTwentyOnePoints() || Dealer.HasOverTwentyOnePoints() || (Player.Points == Dealer.Points && Player.HasStopped && Dealer.HasStopped) ||
		       (Player.Points > Dealer.Points && Player.HasStopped && Dealer.HasStopped);
	}

	public void DecideWinner()
	{
		if (Player.Points > 21)
		{
			Console.WriteLine("Du har förlorat eftersom att du fick över 21 poäng :(");
		}
		else if (Player.Points == 21)
		{
			Console.WriteLine("Du vann eftersom att du fick 21 poäng");
		}
		else if (Player.Points == Dealer.Points)
		{
			Console.WriteLine("Du förlorade eftersom att du och dealern fick samma poäng :(");
		}
		else if (Dealer.Points == 21)
		{
			Console.WriteLine("Dealern vann eftersom att dealern fick 21 poäng");
		}
		else if (Dealer.Points > 21)
		{
			Console.WriteLine("Dealern förlorade eftersom att dealern fick över 21 poäng");
		}
		else if (Player.Points > Dealer.Points)
		{
			Console.WriteLine("Du vann eftersom att du kom närmare 21 poäng än dealern!!");
		}
		else
		{
			Console.WriteLine("Du förlorade eftersom att dealern kom närmare 21 poäng än dig :(");
		}
		
		done = true;
	}

	public bool PlayAgain()
	{
		Console.WriteLine("Vill du spela igen?");
		var choice = Console.ReadLine();
		if (choice == "ja")
		{
			playAgain = true;
			return true;
		}
		else
		{
			playAgain = false;
			return false;
		}

		Player = new Player();
		Dealer = new Dealer();

		isPlayerTurn = true;
	}
}