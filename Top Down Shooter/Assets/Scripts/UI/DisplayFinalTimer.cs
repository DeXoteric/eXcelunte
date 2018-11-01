using TMPro;
using UnityEngine;

public class DisplayFinalTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private TextMeshProUGUI newBestTimeText;

    private TextMeshProUGUI finalTimerText;

    private void Start()
    {
        finalTimerText = GetComponent<TextMeshProUGUI>();

        float elapsedTime = GameManager.instance.Timer;
        string minutes = ((int)elapsedTime / 60).ToString("0");
        string seconds = (elapsedTime % 60).ToString("00.00");

        finalTimerText.text = minutes + ":" + seconds;

        if (PlayerPrefsManager.BestTime < GameManager.instance.Timer)
        {
            PlayerPrefsManager.BestTime = GameManager.instance.Timer;
            PlayerPrefs.Save();
            newBestTimeText.gameObject.SetActive(true);
        }
        else
        {
            finalTimeText.gameObject.SetActive(true);
        }
    }
}