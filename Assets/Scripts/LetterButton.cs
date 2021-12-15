using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LetterButton : MonoBehaviour
{
    public char letter;
    public int scoreValue;
    public int charges;
    public TMP_Text letterText;
    public TMP_Text scoreText;
    public TMP_Text chargesText;
    public GameObject inactiveImage;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        charges = 0;
        UpdateChargesText();
    }

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

    public void Deactivate()
    {
        inactiveImage.SetActive(true);
        button.interactable = false;
    }

    public void Activate()
    {
        inactiveImage.SetActive(false); 
        button.interactable = true;
    }

    public bool IsActive()
    {
        return !inactiveImage.activeSelf;
    }

    public void RemoveCharges(int amount)
    {
        charges = Mathf.Clamp(charges - amount, 0, 99);
        UpdateChargesText();
    }

    public void AddCharges(int amount)
    {
        charges = Mathf.Clamp(charges + amount, 0, 99);
        UpdateChargesText();
    }

    private void UpdateChargesText()
    {
        chargesText.text = charges.ToString();
        if(charges < 1)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }
}
