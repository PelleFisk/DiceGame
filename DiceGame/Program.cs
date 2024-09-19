namespace DiceGame;

public class Program
{
	public static void Main()
	{
		var player = new Player();
		var dealer = new Dealer();

		var game = new Game(player, dealer);
		game.GameLoop();
	}
}