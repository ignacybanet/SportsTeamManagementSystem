namespace SportsTeamManagementSystem;

public class Player
{
    public string Name;
    public string Position;
    public int Score;
    
    public string UpdateScore(string playerName, int newScore)
    {
        if (this.Name == playerName)
        {
            this.Score = newScore;
        }
        return this.Score.ToString();
    }
}


internal class Program
{
    public static void Main(string[] args)
    {
        Player player1 = new Player();
        player1.Name = "Alex";
        Console.WriteLine(player1.Name);
        player1.UpdateScore("Alex", 15);
        Console.WriteLine(player1.Score.ToString());
    }
}