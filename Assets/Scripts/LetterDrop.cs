using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LetterDrop : MonoBehaviour
{
    public float fadeOutRate;
    public TMP_Text letterText;
    private Rigidbody2D rb;
    public Image image;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Init(char s)
    {
        letterText.text = s.ToString().ToUpper();
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-30, 30));
        rb.AddForce(Vector3.up * Random.Range(1, 2), ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(1, 4), ForceMode2D.Impulse);
    }

    private void Update()
    {
        FadeOut();
    }

    private void FadeOut()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - Time.deltaTime * fadeOutRate);
        letterText.color = new Color(letterText.color.r, letterText.color.g, letterText.color.b, letterText.color.a - Time.deltaTime * fadeOutRate);
        if (image.color.a < 1)
        {
            Destroy(gameObject);
        }
    }
}
