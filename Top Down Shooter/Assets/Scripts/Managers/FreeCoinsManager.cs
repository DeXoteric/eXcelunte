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
            freeCoinsTimerText.gameObject.SetActive(true);
            addWillBePlayedText.gameObject.SetActive(true);
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
        if (PlayerPrefsManager.FreeCoins == 0)
        {
            freeCoinTimerStart = ulong.Parse(PlayerPrefsManager.FreeCoinsTimer);
            ulong timeDifference = (ulong)DateTime.Now.Ticks - freeCoinTimerStart;
            ulong timeDifferenceInMiliseconds = timeDifference / TimeSpan.TicksPerMillisecond;

            float timeLeft = (timeInMsToWaitForFreeCoin - timeDifferenceInMiliseconds) / 1000f;

            if (timeLeft <= Mathf.Epsilon)
            {
                PlayerPrefsManager.FreeCoins += 3;
                UpdateFreeCoinsLeft();
            }

            string timerDisplay = "";
            timerDisplay += ((int)timeLeft / 60).ToString() + "m ";
            timerDisplay += ((int)timeLeft % 60).ToString("00") + "s";

            freeCoinsTimerText.text = "Next free coins in: " + timerDisplay;
        }
        else
        {
            freeCoinsTimerText.gameObject.SetActive(false);
            addWillBePlayedText.gameObject.SetActive(false);
        }
    }
}