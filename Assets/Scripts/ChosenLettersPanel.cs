using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenLettersPanel : MonoBehaviour
{
    public int maxLetters;
    public GameObject letterSlotPrefab;
    public List<SelectedLetter> slots;
    public bool canCastWord;

    private int charIndex;

    private void Start()
    {
        charIndex = 0;
        canCastWord = false;
        slots = new List<SelectedLetter>();

        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        for (int i = 0; i < maxLetters; i++)
        {
            var slot = Instantiate(letterSlotPrefab, transform).GetComponent<SelectedLetter>();
            slots.Add(slot);
        }
    }

    private void Update()
    {
        canCastWord = charIndex == maxLetters;
    }

    public void SelectLetter(char c, int scoreValue)
    {
        if (!CanAddLetter()) return;
        
        slots[charIndex].SelectLetter(c, scoreValue);
        charIndex++;
    }

    public void DeleteLetter()
    {
        charIndex = Mathf.Clamp(charIndex - 1, 0, maxLetters);
        slots[charIndex].DeleteLetter();
    }

    private bool CanAddLetter()
    {
        return charIndex < maxLetters;
    }

    public string GetWord()
    {
        string word = "";
        foreach(SelectedLetter s in slots)
        {
            if (s.activeAnchor.activeSelf)
            {
                word += s.letterText.text;
            }
        }
        return word;
    }

    public void ClearAll()
    {
       foreach(SelectedLetter s in slots)
        {
            s.DeleteLetter();
        }
        charIndex = 0;
    }
}
