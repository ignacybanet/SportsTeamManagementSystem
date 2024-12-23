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
    
    public static void UpdateScore(Player player, int newScore) // obiekt jako parametr funkcji // TODO: change method to take playerName and playerPosition as arguments, change it so that it updates the score in the ListOfPlayers list of Team class instead of here.
    {
        player.Score = newScore;
        Console.WriteLine($"{player.Name}'s player score now: {newScore}");
    }
    
    public static void SearchForPlayerByPosition(string position)
    {
        // TODO: use delegates and anonymous functions
    }

    public static void DisplayTeamStatistics()
    {
        // TODO: no requirements
    }
    
    public static void CalculateAverageScore()
    {
        // TODO: use static function
    }
}

public class Team
{
    public static List<Player> ListOfPlayers = new List<Player>(); // lista zawodnikow
    
    public static void AddNewPlayer(string playerName, string playerPosition) // TODO: use interface to create new players
    {
        ListOfPlayers.Add(new Player(playerName, playerPosition)); // dodawanie zawodnikow do wczesniej wspomnianej listy zawodnikow
        Console.WriteLine($"Player {playerName}, with position {playerPosition} added to the list of players");
    }

    public static void RemovePlayer(string playerName, string playerPosition)
    {
        ListOfPlayers.Remove(ListOfPlayers.Find(x => x.Name == playerName)); // usuwanie graczy za pomoca Find() i wyrazenia lambda
        Console.WriteLine($"Player {playerName}, with position {playerPosition} removed from the list of players");
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        Team.AddNewPlayer("Max","Defender");
    }
}