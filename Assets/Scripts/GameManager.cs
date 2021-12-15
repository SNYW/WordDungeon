using System;
using System.Collections;
using System.Collections.Generic;
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
    public int currentLevel;
    public Enemy currentEnemy;
    public GameObject enemyPrefab;
    public Transform enemySpawnAnchor;
    public Area currentArea;

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
        currentLevel = 0;
        currentEnemy.Init(8);
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
        LetterKeyboard.instance.FindButtonWithLetter(c).RemoveCharges(1);
    }

    public void CastWord()
    {
        if (WordManager.GetWordScore(out int score, chosenLettersPanel.GetWord().ToLower()))
        {
            combatText.UpdateSpellText(chosenLettersPanel.GetWord(), score);
            combatTextManager.AddTextRequest(combatText);
            chosenLettersPanel.ClearAll();
            SpawnOnHitLetters(score);
            currentEnemy.TakeDamage(score);
        }
    }

    private void SpawnOnHitLetters(int s)
    {
        SpawnVowels(2);
        SpawnConsonants(s / 2);
    }

    private void SpawnVowels(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var letterDrop = Instantiate(letterDropPrefab, letterDropAnchor.position, Quaternion.identity).GetComponent<LetterDrop>();
            var letter = WordManager.vowels[Random.Range(0, WordManager.vowels.Length - 1)];

            letterDrop.Init(letter);
            LetterKeyboard.instance.FindButtonWithLetter(letter).AddCharges(1);
        }
    }

    private void SpawnConsonants(int amount)
    {
        for (int i = 0; i < amount; i++)
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

    public void SpawnNewEnemy()
    {
        currentArea.Move(5);
        StartCoroutine(DelayedSpawn());
    }

    public IEnumerator DelayedSpawn()
    {
        yield return new WaitUntil(() => !currentArea.Moving());
        currentLevel++;
        currentEnemy = Instantiate(enemyPrefab, enemySpawnAnchor).GetComponent<Enemy>();
        letterDropAnchor = currentEnemy.transform;
        currentEnemy.Init(currentLevel * 8);
    }

}
