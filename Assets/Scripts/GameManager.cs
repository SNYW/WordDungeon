using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public CombatTextManager combatTextManager;
    public CombatText combatText;
    public LetterKeyboard letterKeyboard;
    public ChosenLettersPanel chosenLettersPanel;
    public GameObject castButton;

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
            Debug.Log($"You Scored {score} points!");
        }

        chosenLettersPanel.ClearAll();
    }
        
    public bool CanCastWord()
    {
        return chosenLettersPanel.canCastWord;
    }

}
