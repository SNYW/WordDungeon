using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public TMP_Text healthBarText;

    public void UpdateHealthBar(int current, int max)
    {
        healthBarImage.fillAmount = (float)current / max;
        healthBarText.text = $"{current} / {max}";
    }
}
