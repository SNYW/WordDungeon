using UnityEngine;
using TMPro;

public class SelectedLetter : MonoBehaviour
{
    public TMP_Text letterText;
    public TMP_Text scoreText;
    public GameObject activeAnchor;

    private void Start()
    {
        activeAnchor.SetActive(false);
    }

    public void SelectLetter(char c, int score)
    {
        letterText.text = c.ToString().ToUpper();
        scoreText.text = score.ToString();
        activeAnchor.SetActive(true);
    }

    public void DeleteLetter()
    {
        activeAnchor.SetActive(false);
    }


}
