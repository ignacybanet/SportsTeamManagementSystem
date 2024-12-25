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
    
    public static void UpdateScore(string playerName, string playerPosition, int newScore)
    {
        Player foundPlayer = Team.ListOfPlayers.Find(player => player.Name == playerName && player.Position == playerPosition); // znalezienie gracza w liscie graczy. trzeba zdefiniowac foundPlayer jako obiekt klasy Player, inaczej nie zadziala
        foundPlayer.Score = newScore;
        Console.WriteLine($"{foundPlayer.Name}'s player score now: {newScore}");
    }
    
    public static void SearchForPlayersByPosition(string position)
    {
        // TODO: use delegates and anonymous functions
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
    
    public static void DisplayTeamStatistics()
    {
        int totalTeamScore = 0;
        Player highestScoringPlayer = null;
        foreach (var player in ListOfPlayers)
        {
            totalTeamScore += player.Score; // sumowanie wyniku graczy w kazdej iteracji petli
            if (highestScoringPlayer == null || player.Score > highestScoringPlayer.Score) // za pierwsza iteracja `highestScoringPlayer == null` zwroci `true`, wiec bedzie on najlepszym graczem, a w nastepnych iteracjach `player.Score` jest porownywany z aktualnym najlepszym graczem. jezeli zwroci `true`, wtedy jest on przypisywany jako najlepszy gracz.
            {
                highestScoringPlayer = player;
            }
        }
        
        // calculate the lowest scoring player on the team
        Player lowestScoringPlayer = null;
        foreach (var player in ListOfPlayers)
        {
            if (lowestScoringPlayer == null || player.Score < lowestScoringPlayer.Score) // ta sama logika ale odwrocone warunki
            {
                lowestScoringPlayer = player;
            }
        }
        Console.WriteLine($"\nTeam statistics:");
        Console.WriteLine($"Total team score: {totalTeamScore}");
        Console.WriteLine($"The highest scoring player is {highestScoringPlayer.Name} and their score is {highestScoringPlayer.Score}");
        Console.WriteLine($"The lowest scoring player is {lowestScoringPlayer.Name} and their score is {lowestScoringPlayer.Score}");
    }
    
    public static void CalculateAverageScore()
    {
        // TODO: use static function
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        Team.AddNewPlayer("John","Attacker");
        Player.UpdateScore("John","Attacker",35);
        Team.DisplayTeamStatistics();
    }
}