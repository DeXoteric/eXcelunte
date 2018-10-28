using System;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private UnityAds unityAds;
    private SceneLoader sceneLoader;

    private void Start()
    {
        unityAds = FindObjectOfType<UnityAds>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void Play()
    {
        if (PlayerPrefsManager.FreeCoins == 0)
        {
            unityAds.PlayAd();
        }
        else
        {
            sceneLoader.LoadGame();
            ulong freeCoinTimerStart = (ulong)DateTime.Now.Ticks;
            if (PlayerPrefsManager.FreeCoins == 3)
            {
                PlayerPrefsManager.FreeCoinsTimer = freeCoinTimerStart.ToString();
            }
            PlayerPrefsManager.FreeCoins -= 1;
        }
    }
}