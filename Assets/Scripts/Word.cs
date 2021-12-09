public class Word
{
    public int scoreValue;
    public string chars;

    public Word(string s)
    {
        chars = s;
        SetScoreValue(s);
    }

    private void SetScoreValue(string chars)
    {
        if (WordManager.GetWordScoreRaw(out var score, chars))
            scoreValue = score;
    }
}
