using TMPro;
using UnityEngine;

public class DisplayTimer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float startTime = 0;
    private float elapsedTime;
    private PlayerHealthController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealthController>();
        timerText = GetComponent<TextMeshProUGUI>();
        timerText.text = "0:00.00";
    }

    private void Update()
    {
        if (GameManager.instance.GameStarted && startTime == 0)
        {
            startTime = Time.time;
        }
        else if (GameManager.instance.GameStarted && startTime != 0 && player.GetPlayerHealth() > 0)
        {
            elapsedTime = Time.time - startTime;

            string minutes = ((int)elapsedTime / 60).ToString("0");
            string seconds = (elapsedTime % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;

            GameManager.instance.Timer = elapsedTime;
        }
    }
}