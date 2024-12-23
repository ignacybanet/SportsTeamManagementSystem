namespace SportsTeamManagementSystem;

public class Player
{
    public string Name;
    public string Position;
    public int Score;

    public Player(string name, string position)
    {
        Name = name;
        Position = position;
        Score = 0; // wynik jest domyslnie rowny 0
    }

    public static void UpdateScore(Player player, int newScore) // obiekt jako parametr funkcji
    {
        player.Score = newScore;
        Console.WriteLine($"{player.Name}'s player score now: {newScore}");
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        Player alex = new Player("Alex", "Goalkeeper");
        Player bob = new Player("Bob", "Defender");
        Player.UpdateScore(alex, 30);
    }
}