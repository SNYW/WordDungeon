using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public static class WordManager
{
    public static List<string> threeLetterWords;
    public static List<string> fourLetterWords;
    public static List<string> fiveLetterWords;
    public static List<string> sixLetterWords;
    public static Dictionary<string, Word> words;
    public static char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    public static int[] values = { 1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 3, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 4, 10 };

    public static void Init()
    {
        threeLetterWords = new List<string>();
        fourLetterWords = new List<string>();
        fiveLetterWords = new List<string>();
        sixLetterWords = new List<string>();
        words = new Dictionary<string, Word>();

        var wordArray = Resources.Load<TextAsset>("ScrabbleWords").text.Split('\n');

        foreach(string word in wordArray)
        {
            var cleanWord = word.Trim().ToLower();
            switch (cleanWord.Length)
            {
                case 3:
                    threeLetterWords.Add(cleanWord);
                    break;
                case 4:
                    fourLetterWords.Add(cleanWord);
                    break;
                case 5:
                    fiveLetterWords.Add(cleanWord);
                    break;
                case 6:
                    sixLetterWords.Add(cleanWord);
                    break;
            }
            Word newWord = new Word(cleanWord);
            words.Add(cleanWord, newWord);
        }
    }

    private static List<string> GetTargetWordList(int len)
    {
        return len switch
        {
            3 => threeLetterWords,
            4 => fourLetterWords,
            5 => fiveLetterWords,
            6 => sixLetterWords,
            _ => null,
        };
    }

    public static int GetLetterScore(char letter)
    {
        var index = 0;
        foreach(char c in alphabet)
        {
            if(letter == c)
            {
                return values[index];
            }
            index++;
        }

        return 0;
    }

    public static bool GetWordScore(out int score, string word)
    {
        if (words.ContainsKey(word))
        {
            score = words[word].scoreValue;
        }
        else
        {
            score = 0;
        }
        return score > 0;
    }

    public static bool GetWordScoreRaw(out int score, string word)
    {
        score = 0;

        foreach(char c in word.ToCharArray())
        {
            score += GetLetterScore(c);
        }

        return score > 0;
    }

    public static char[] GetCharacterList()
    {
        return alphabet;
    }
}
