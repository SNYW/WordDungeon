using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour
{
    private Button button;
    public ChosenLettersPanel chosenLettersPanel;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        button.interactable = chosenLettersPanel.CanDeleteLetter();
    }
}
