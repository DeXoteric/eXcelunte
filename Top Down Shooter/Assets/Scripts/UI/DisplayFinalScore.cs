using TMPro;
using UnityEngine;

public class DisplayFinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI newHighScoreText;

    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = GameManager.instance.GetScore().ToString();

        if (PlayerPrefsManager.HighScore < GameManager.instance.GetScore())
        {
            PlayerPrefsManager.HighScore = GameManager.instance.GetScore();
            PlayerPrefs.Save();
            newHighScoreText.gameObject.SetActive(true);
        }
        else
        {
            finalScoreText.gameObject.SetActive(true);
        }
    }
}