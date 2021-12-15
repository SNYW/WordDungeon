using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LetterKeyboard : MonoBehaviour
{
    public GameObject letterPrefab;
    public int startVowels;
    public int startConsonants;
    public List<LetterButton> buttons;

    public static LetterKeyboard instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void SpawnKeyboard()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        foreach(char c in WordManager.GetCharacterList())
        {
            var letterKey = Instantiate(letterPrefab, transform).GetComponent<LetterButton>();
            letterKey.Init(c, WordManager.GetLetterScore(c));
            letterKey.Deactivate();
            buttons.Add(letterKey);
        }

        InitVowels();
        InitConsonants();
    }

    private void InitConsonants()
    {
        for (int i = 0; i < startConsonants; i++)
        {
            List<char> consonantsLeft = new List<char>(WordManager.consonants);
            var targetChar = consonantsLeft[Random.Range(0, consonantsLeft.Count - 1)];
            FindButtonWithLetter(targetChar).AddCharges(1);
            consonantsLeft.Remove(targetChar);
        }
    }

    private void InitVowels()
    {
        for (int i = 0; i < startVowels; i++)
        {
            List<char> vowelsLeft = new List<char>(WordManager.vowels);
            var targetChar = vowelsLeft[Random.Range(0, vowelsLeft.Count - 1)];
            FindButtonWithLetter(targetChar).AddCharges(1);
            vowelsLeft.Remove(targetChar);
        }
    }

    public LetterButton FindButtonWithLetter(char c)
    {
        return buttons.Find(button => button.letter == c);
    }
}
