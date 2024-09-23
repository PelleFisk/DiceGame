namespace DiceGame;

public class Program
{
	public static void Main()
	{
		Console.WriteLine("Välkommen till spelet 21!");

		var playAgain = true;
		var player = new Player();
		while (playAgain)
		{
			var game = new Game(player);
			game.GameLoop();

			game.ResetGame();

			Console.WriteLine("Vill du spela igen? ja/nej");
			var answer = Console.ReadLine().ToLower();
			playAgain = answer == "ja";
		}

		Console.WriteLine("Tack för att du spelade!");
	}
}
