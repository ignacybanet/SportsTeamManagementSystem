public class Player
{
    public string Name;
    public string Position;
    public int Score;

    public Player(string name, string position, int score)
    {
        Name = name;
        Position = position;
        Score = score;
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
        var playersMatchingPosition = Team.ListOfPlayers.FindAll(player => player.Position == position); // znalezienie wszystkich graczy ktorzy odpowiadaja argumentowi funkcji za pomoca FindAll i lambdy
        if (playersMatchingPosition.Count == 0) // sprawdzenie czy sa gracze z ta pozycja
        {
            Console.WriteLine("No matching players found");
        }
        else
        {
            Console.WriteLine($"Players with the {position} position:");
            foreach (var player in playersMatchingPosition)
            {
                Console.WriteLine($"Name: {player.Name}, Score: {player.Score}");
            }
        }
    }
}

public class Team
{
    public static List<Player> ListOfPlayers = new List<Player>(); // lista zawodnikow
    
    public static void AddNewPlayer(string playerName, string playerPosition, int playerScore) // TODO: use interface to create new players
    {
        ListOfPlayers.Add(new Player(playerName, playerPosition, playerScore)); // dodawanie zawodnikow do wczesniej wspomnianej listy zawodnikow
        Console.WriteLine($"Player {playerName}, with position {playerPosition} and score {playerScore} added to the list of players");
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
    
    public static void CalculateAverageTeamScore()
    {
        double totalTeamScore = 0d;
        foreach (var player in ListOfPlayers)
        {
            totalTeamScore += player.Score;
        }
        double averageScore = totalTeamScore / ListOfPlayers.Count;
        Console.WriteLine($"Average team score: {averageScore}");
    }
}

class UI
{
    public static void DisplayWarningMessage()
    {
        Console.WriteLine("You must fill out all fields");
    }
    public static void ShowUI()
    {
        while(true) // interfejs bedzie ciagle sie pojawiac
        {
            Console.WriteLine("\nChoose an option\n1 - Add a new player\n2 - Remove a player\n3 - Update a player's score\n4 - Display team's statistics\n5 - Calculate the average team score\n6 - Search for players by position");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            
            // wiem ze to jest przeciwienstwo DRY ale nie wiedzialem jak inaczej to zrobic
            switch (userChoice)
            {
                case 1: // dodanie gracza
                    string playerName = "";
                    string playerPosition = "";
                    int playerScore = 0;
                    bool requiredFieldsAreEmpty = true;
                    
                    while(requiredFieldsAreEmpty)
                    {
                        Console.WriteLine("Input the new player's name:");
                        playerName = Console.ReadLine();
                
                        Console.WriteLine("Input the new player's position:");
                        playerPosition = Console.ReadLine();
                
                        Console.WriteLine("Input the new player's score:");
                        playerScore = Convert.ToInt32(Console.ReadLine());
                        
                        if (playerName == "" || playerPosition == "" || playerScore == 0)
                        {
                            DisplayWarningMessage();
                            requiredFieldsAreEmpty = true;
                        }
                        else
                        {
                            requiredFieldsAreEmpty = false;
                        }
                    }
                    Team.AddNewPlayer(playerName, playerPosition, playerScore);
                    Thread.Sleep(2000);
                    break;
            
                case 2: // usuniecie gracza
                    string playerToBeRemovedName = "";
                    string playerToBeRemovedPosition = "";
                    requiredFieldsAreEmpty = true;

                    while(requiredFieldsAreEmpty)
                    {
                        Console.WriteLine("Input the player's name who will be removed:");
                        playerToBeRemovedName = Console.ReadLine();
                
                        Console.WriteLine("Input the player's position who will be removed:");
                        playerToBeRemovedPosition = Console.ReadLine();

                        if (playerToBeRemovedName == "" || playerToBeRemovedPosition == "")
                        {
                            DisplayWarningMessage();
                            requiredFieldsAreEmpty = true;
                        }
                        else
                        {
                            requiredFieldsAreEmpty = false;
                        }
                    }
                    Team.RemovePlayer(playerToBeRemovedName, playerToBeRemovedPosition);
                    Thread.Sleep(2000);
                    break;
            
                case 3: // zmiana wyniku
                    string playerToBeUpdatedName = "";
                    string playerToBeUpdatedPosition = "";
                    int newPlayerScore = 0;
                    requiredFieldsAreEmpty = true;

                    while(requiredFieldsAreEmpty)
                    {
                        Console.WriteLine("Input the player's name whose score will be updated:");
                        playerToBeUpdatedName = Console.ReadLine();
                
                        Console.WriteLine("Input the player's position whose score will be updated:");
                        playerToBeUpdatedPosition = Console.ReadLine();
                
                        Console.WriteLine("Input the player's new score:");
                        newPlayerScore = Convert.ToInt32(Console.ReadLine());
                        
                        if (playerToBeUpdatedName == "" || playerToBeUpdatedPosition == "")
                        {
                            DisplayWarningMessage();
                            requiredFieldsAreEmpty = true;
                        }
                        else
                        {
                            requiredFieldsAreEmpty = false;
                        }
                    }
                    Player.UpdateScore(playerToBeUpdatedName, playerToBeUpdatedPosition, newPlayerScore);
                    Thread.Sleep(2000);
                    break;
                
                case 4: // wyswietlenie statystyk
                    Team.DisplayTeamStatistics();
                    Thread.Sleep(6500);
                    break;
                
                case 5: // obliczenie sredniej
                    Team.CalculateAverageTeamScore();
                    Thread.Sleep(4000);
                    break;
                
                case 6:
                    string position = "";
                    requiredFieldsAreEmpty = true;

                    while (requiredFieldsAreEmpty)
                    {
                        Console.WriteLine("Input the name of the position of which players will be searched:");
                        position = Console.ReadLine();
                        if (position == "")
                        {
                            DisplayWarningMessage();
                            requiredFieldsAreEmpty = true;
                        }
                        else
                        {
                            requiredFieldsAreEmpty = false;
                        }
                    }
                    Player.SearchForPlayersByPosition(position);
                    Thread.Sleep(4000);
                    break;
                
                default:
                    Console.WriteLine("Please enter a valid option");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        UI.ShowUI();
    }
}