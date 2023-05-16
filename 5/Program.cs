using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "E:\\text.txt"; 
        Dictionary<string, int> wordFrequencies = new Dictionary<string, int>();
        string[] words = File.ReadAllText(filePath).ToLower().Split(' ');
        foreach (string word in words)
        {
            if (wordFrequencies.ContainsKey(word))
            {
                wordFrequencies[word]++;
            }
            else
            {
                wordFrequencies[word] = 1;
            }
        }
        var sortedWords = wordFrequencies.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
        int count = 0;
        foreach (var wordFrequency in sortedWords)
        {
            Console.WriteLine("{0}: {1}", wordFrequency.Key, wordFrequency.Value);
            count++;

            if (count >= 10)
            {
                break;
            }
        }
    }
}
