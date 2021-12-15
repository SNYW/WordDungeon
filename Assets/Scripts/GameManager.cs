using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public CombatTextManager combatTextManager;
    public CombatText combatText;
    public LetterKeyboard letterKeyboard;
    public ChosenLettersPanel chosenLettersPanel;
    public GameObject castButton;
    public GameObject letterDropPrefab;
    public Transform letterDropAnchor;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this);
        }

        WordManager.Init();
    }

    private void Start()
    {
        letterKeyboard.SpawnKeyboard();
    }

    private void Update()
    {
        castButton.GetComponent<Button>().interactable = chosenLettersPanel.canCastWord;
    }

    public void AddCharToWord(char c, int scoreValue)
    {
        chosenLettersPanel.SelectLetter(c, scoreValue);
    }

    public void CastWord()
    {
        if(WordManager.GetWordScore(out int score, chosenLettersPanel.GetWord().ToLower()))
        {
            combatText.UpdateSpellText(chosenLettersPanel.GetWord(), score);
            combatTextManager.AddTextRequest(combatText);
        }

        chosenLettersPanel.ClearAllCast();
        SpawnOnHitLetters(score);
    }

    private void SpawnOnHitLetters(int s)
    {
        for (int i = 0; i < s/2+2; i++)
        {
            var letterDrop = Instantiate(letterDropPrefab, letterDropAnchor.position, Quaternion.identity).GetComponent<LetterDrop>();
            var letter = WordManager.vowels[Random.Range(0, WordManager.vowels.Length - 1)];

            letterDrop.Init(letter);
            LetterKeyboard.instance.FindButtonWithLetter(letter).AddCharges(1);
        }
        for (int i = 0; i < s/2; i++)
        {
            var letterDrop = Instantiate(letterDropPrefab, letterDropAnchor.position, Quaternion.identity).GetComponent<LetterDrop>();
            var letter = WordManager.consonants[Random.Range(0, WordManager.consonants.Length - 1)];

            letterDrop.Init(letter);
            LetterKeyboard.instance.FindButtonWithLetter(letter).AddCharges(1);
        }
    }

    public bool CanCastWord()
    {
        return chosenLettersPanel.canCastWord;
    }

}
