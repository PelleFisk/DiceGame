namespace DiceGame;

public class Program
{
	public static void Main()
	{
		var playAgain = true;
		while (playAgain)
		{
			var game = new Game();
			game.GameLoop();
		}
	}
}
