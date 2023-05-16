using System;

class CountingGame
{
    private string[] players;
    private int currentPlayerIndex;

    public void InitializePlayers(string[] playerNames)
    {
        if (playerNames.Length < 5 || playerNames.Length > 10)
        {
            Console.WriteLine("Количество игроков должно быть от 5 до 10.");
            return;
        }

        players = playerNames;
        currentPlayerIndex = 0;
    }

    public string PlayGame(string countingString, string startingPlayerName)
    {
        int startingPlayerIndex = Array.IndexOf(players, startingPlayerName);
        if (startingPlayerIndex == -1)
        {
            Console.WriteLine("Игрок с именем {0} не найден.", startingPlayerName);
            return null;
        }

        int wordIndex = 0;
        string[] words = countingString.Split(' ');

        while (words.Length > 1)
        {
            int currentPlayerIndexOffset = wordIndex % players.Length;
            currentPlayerIndex = (startingPlayerIndex + currentPlayerIndexOffset) % players.Length;

            int wordLength = words[wordIndex].Length;
            startingPlayerIndex = (startingPlayerIndex + wordLength) % players.Length;

            Array.Copy(words, wordIndex + 1, words, wordIndex, words.Length - wordIndex - 1);
            Array.Resize(ref words, words.Length - 1);

            wordIndex = (wordIndex + 1) % words.Length;
        }

        return players[currentPlayerIndex];
    }
}

class Program
{
    static void Main()
    {
        string[] playerNames = { "Игрок1", "Игрок2", "Игрок3", "Игрок4", "Игрок5" }; 
        CountingGame game = new CountingGame();
        game.InitializePlayers(playerNames);

        Console.WriteLine("Введите строку считалки:");
        string countingString = Console.ReadLine();

        Console.WriteLine("Введите имя игрока, с которого нужно начать:");
        string startingPlayerName = Console.ReadLine();

        string lastPlayer = game.PlayGame(countingString, startingPlayerName);
        Console.WriteLine("Последнее слово попадает на игрока: " + lastPlayer);
    }
}
