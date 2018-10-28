using TMPro;
using UnityEngine;

public class DisplayHighScore : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
        highScoreText.text = PlayerPrefsManager.HighScore.ToString();
    }
}