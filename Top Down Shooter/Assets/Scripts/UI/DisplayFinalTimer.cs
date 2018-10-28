using TMPro;
using UnityEngine;

public class DisplayFinalTimer : MonoBehaviour
{
    private TextMeshProUGUI finalTimerText;

    private void Start()
    {
        finalTimerText = GetComponent<TextMeshProUGUI>();

        float elapsedTime = GameManager.instance.Timer;
        string minutes = ((int)elapsedTime / 60).ToString("0");
        string seconds = (elapsedTime % 60).ToString("f2");

        finalTimerText.text = minutes + ":" + seconds;

        if (PlayerPrefsManager.BestTime < GameManager.instance.Timer)
        {
            PlayerPrefsManager.BestTime = GameManager.instance.Timer;
            PlayerPrefs.Save();
        }
        else
        {
        }
    }
}