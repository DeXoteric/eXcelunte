using System;
using TMPro;
using UnityEngine;

public class FreeCoinsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI freeCoinsLeftText;
    [SerializeField] private TextMeshProUGUI freeCoinsTimerText;
    [SerializeField] private TextMeshProUGUI addWillBePlayedText;

    [SerializeField] private float timeInMsToWaitForFreeCoin;

    private ulong freeCoinTimerStart;

    private void Start()

    {
        freeCoinTimerStart = ulong.Parse(PlayerPrefsManager.FreeCoinsTimer);

        UpdateFreeCoinsLeft();

        if (PlayerPrefsManager.FreeCoins == 0)
        {
            addWillBePlayedText.gameObject.SetActive(true);
        }
        else if (PlayerPrefsManager.FreeCoins < 3)
        {
            freeCoinsTimerText.gameObject.SetActive(true);
            addWillBePlayedText.gameObject.SetActive(false);
        }
        else
        {
            freeCoinsTimerText.gameObject.SetActive(false);
            addWillBePlayedText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        UpdateFreeCoinsTimer();
    }

    private void UpdateFreeCoinsLeft()
    {
        freeCoinsLeftText.text = "Free Coins Left: " + PlayerPrefsManager.FreeCoins + "/" + GameManager.instance.GetFreeCoins();
    }

    private void UpdateFreeCoinsTimer()
    {
        if (PlayerPrefsManager.FreeCoins < 3)
        {
            freeCoinTimerStart = ulong.Parse(PlayerPrefsManager.FreeCoinsTimer);
            ulong timeDifference = (ulong)DateTime.Now.Ticks - freeCoinTimerStart;
            ulong timeDifferenceInMiliseconds = timeDifference / TimeSpan.TicksPerMillisecond;

            float timeLeft = (timeInMsToWaitForFreeCoin - timeDifferenceInMiliseconds) / 1000f;

            if (timeLeft <= Mathf.Epsilon)
            {
                PlayerPrefsManager.FreeCoins = GameManager.instance.GetFreeCoins();
                UpdateFreeCoinsLeft();
            }

            string timerDisplay = "";
            timerDisplay += ((int)timeLeft / 60).ToString() + ":";
            timerDisplay += ((int)timeLeft % 60).ToString("00");

            freeCoinsTimerText.text = "New free coins in: " + timerDisplay;
        }
        else
        {
            freeCoinsTimerText.gameObject.SetActive(false);
            addWillBePlayedText.gameObject.SetActive(false);
        }
    }
}