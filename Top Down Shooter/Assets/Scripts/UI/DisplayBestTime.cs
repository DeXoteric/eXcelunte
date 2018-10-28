using TMPro;
using UnityEngine;

public class DisplayBestTime : MonoBehaviour
{
    private TextMeshProUGUI bestTimeText;

    private void Start()
    {
        bestTimeText = GetComponent<TextMeshProUGUI>();

        float elapsedTime = PlayerPrefsManager.BestTime;
        string minutes = ((int)elapsedTime / 60).ToString("0");
        string seconds = (elapsedTime % 60).ToString("f2");

        bestTimeText.text = minutes + ":" + seconds;
    }
}