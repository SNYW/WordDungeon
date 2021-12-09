using UnityEngine;

public class LetterKeyboard : MonoBehaviour
{
    public GameObject letterPrefab;
    private char[] charList = "QWERTYUIOPASDFGHJKLZXCVBNM".ToLower().ToCharArray();
    public void SpawnKeyboard()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        foreach(char c in WordManager.GetCharacterList())
        {
            var letterKey = Instantiate(letterPrefab, transform);
            letterKey.GetComponent<LetterButton>().Init(c, WordManager.GetLetterScore(c));
        }
    }
}
