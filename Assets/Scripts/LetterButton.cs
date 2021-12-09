using UnityEngine;
using TMPro;

public class LetterButton : MonoBehaviour
{
    public char letter;
    public int scoreValue;
    public TMP_Text letterText;
    public TMP_Text scoreText;

    public void Init(char c, int score)
    {
        letter = c;
        scoreValue = WordManager.GetLetterScore(c);
        letterText.text = c.ToString().ToUpper();
        scoreText.text = score.ToString();
    }

    public void AddCharToWord()
    {
        GameManager.gm.AddCharToWord(letter, scoreValue);
    }
}
