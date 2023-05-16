using System;
using System.Collections.Generic;
struct Match
{
    public string TeamA;
    public string TeamB;
    public int ScoreA;
    public int ScoreB;

    public Match(string teamA, string teamB)
    {
        TeamA = teamA;
        TeamB = teamB;
        ScoreA = 0;
        ScoreB = 0;
    }
}
class Node
{
    public string Team;
    public Node LeftChild;
    public Node RightChild;
    public Match Match;

    public Node(string team)
    {
        Team = team;
        LeftChild = null;
        RightChild = null;
        Match = new Match("", "");
    }
}

class Program
{
    static Random random = new Random();

    static void Main()
    {
        string[] teamNames = { "BRA", "ARG", "FRA", "COL", "CHI", "URU", "GER", "ALG", "CRC", "MEX", "NED", "GRE", "BEL", "SWI", "USA" };
        Node root = CreateTree(teamNames, 0, teamNames.Length - 1);
        GenerateResults(root);
        PrintResults(root);
    }
    static Node CreateTree(string[] teamNames, int start, int end)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;
        Node node = new Node(teamNames[mid]);

        node.LeftChild = CreateTree(teamNames, start, mid - 1);
        node.RightChild = CreateTree(teamNames, mid + 1, end);

        return node;
    }
    static void GenerateResults(Node node)
    {
        if (node == null)
            return;

        GenerateResults(node.LeftChild);
        GenerateResults(node.RightChild);

        if (node.LeftChild != null && node.RightChild != null)
        {
            node.Match.TeamA = node.LeftChild.Team;
            node.Match.TeamB = node.RightChild.Team;
            node.Match.ScoreA = random.Next(0, 4);
            node.Match.ScoreB = random.Next(0, 4);
        }
    }
    static void PrintResults(Node node)
    {
        if (node == null)
            return;

        PrintResults(node.LeftChild);
        PrintResults(node.RightChild);

        if (node.LeftChild != null && node.RightChild != null)
        {
            Console.WriteLine("{0} - {1} : {2} - {3}", node.Match.TeamA, node.Match.TeamB, node.Match.ScoreA, node.Match.ScoreB);
        }
    }
}

