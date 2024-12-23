namespace SportsTeamManagementSystem;

public class Player(string name, string position, int score)
{
    public string Name = name;
    public string Position = position;
    public int Score = score;

    public static void UpdateScore(string playerName, int newScore)
    {
            Console.WriteLine($"{playerName}'s player score: {newScore}");
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        Player alex = new Player("alex","position1",10);
        Player.UpdateScore("Alex",20);
    }
}