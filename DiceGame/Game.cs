namespace DiceGame;

public class Game(Player player, Dealer dealer)
{
	public Player Player { get; set; } = player;
	public Dealer Dealer { get; set; } = dealer;
	private bool isPlayerTurn = true;
	private bool playAgain = true;
	private int moneyInThePot;
	private bool shouldSkipLastText;

	public void GameLoop()
	{
		while (playAgain)
		{
			if (isPlayerTurn && !Player.HasStopped)
			{
				Player.PlayTurn();
				// Hello
				Dealer.PlayTurn();
				
				if (Player.HasStopped)
					continue;
				
				if (BaseCasesAreTrue())
					DecideWinner();
				
				Console.WriteLine($"Du slog: {Player.RollPoints}, din totala poäng är: {Player.Points}");
				Console.WriteLine($"Dealern slog: {Dealer.RollPoints}, dealerns totala poäng är: {Dealer.Points}");
			}
			else
			{
				Dealer.PlayTurn();
				Console.WriteLine($"Dealern slog: {Dealer.RollPoints}, dealerns totala poäng är: {Dealer.Points}");
				
				Player.PlayTurn(false);

				if (BaseCasesAreTrue())
					DecideWinner();
				
				Console.WriteLine($"Du slog: {Player.RollPoints}, din totala poäng är: {Player.Points}");
				Console.WriteLine($"Dealerns poäng är: {Dealer.Points}");
			}

			isPlayerTurn = !isPlayerTurn;
		}
	}

	public bool BaseCasesAreTrue()
	{
		return Player.HasTwentyOnePoints() || Player.HasOverTwentyOnePoints() || Dealer.HasTwentyOnePoints() || Dealer.HasOverTwentyOnePoints() || (Player.Points == Dealer.Points && Player.HasStopped);
	}

	public void DecideWinner()
	{
		if (Player.Points > 21)
		{
			Console.WriteLine("Du har förlorat eftersom att du fick över 21 poäng :(");
		}
		else if (Player.Points == Dealer.Points)
		{
			Console.WriteLine("Du förlorade eftersom att du och dealern fick samma poäng :(");
		}
		else
		{
			Console.WriteLine("Du vann eftersom att du kom närmare 21 poäng än dealern!!");
		}

		Console.WriteLine("Vill du spela igen?");
		var choice = Console.ReadLine();
		if (choice == "ja")
			playAgain = true;
		else
			playAgain = false;
	}
}