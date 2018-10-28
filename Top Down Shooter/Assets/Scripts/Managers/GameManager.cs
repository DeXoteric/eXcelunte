using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int score;

    private int freeCoins = 3;

    public int DoubleScoreMultiplier { get; set; }

    public bool IsOnMobile { get; private set; }
    public bool IsShieldEnabled { get; set; }
    public bool IsDoubleScoreEnabled { get; set; }
    public bool IsTripleShotEnabled { get; set; }

    public bool GameStarted { get; set; }

    private void Awake()
    {
        SetUpSingleton();
        CheckIfOnMobile();
        GameStarted = false;
    }

    private void CheckIfOnMobile()
    {
#if UNITY_ANDROID || UNITY_IOS
        IsOnMobile = true;
#endif
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        IsOnMobile = false;
#endif
    }

    private void SetUpSingleton()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreToAdd)
    {
        if (IsDoubleScoreEnabled)
        {
            score += (scoreToAdd * DoubleScoreMultiplier * 2);
        }
        else if (!IsDoubleScoreEnabled)
        {
            score += scoreToAdd;
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public int GetFreeCoins()
    {
        return freeCoins;
    }
}