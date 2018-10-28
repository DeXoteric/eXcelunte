using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static PlayerPrefsManager instance;

    private const string MUSIC_VOLUME_FLOAT = "musicVolume";
    private const string SFX_VOLUME_FLOAT = "sfxVolume";
    private const string AUDIO_ENABLED_INT = "isAudioEnabled";

    public const string HIGH_SCORE = "highScore";

    private const string APP_VERSION = "appVersion";

    private void Awake()
    {
        SetUpSingleton();
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

    public static float MusicVolume
    {
        get { return PlayerPrefs.GetFloat(MUSIC_VOLUME_FLOAT, 1f); }
        set { PlayerPrefs.SetFloat(MUSIC_VOLUME_FLOAT, value); }
    }

    public static float SfxVolume
    {
        get { return PlayerPrefs.GetFloat(SFX_VOLUME_FLOAT, 1f); }
        set { PlayerPrefs.SetFloat(SFX_VOLUME_FLOAT, value); }
    }

    public static bool IsAudioEnabled
    {
        get { return PlayerPrefs.GetInt(AUDIO_ENABLED_INT, 1) != 0; }
        set { PlayerPrefs.SetInt(AUDIO_ENABLED_INT, value ? 1 : 0); }
    }

    public static int HighScore
    {
        get { return PlayerPrefs.GetInt(HIGH_SCORE, 0); }
        set { PlayerPrefs.SetInt(HIGH_SCORE, value); }
    }

    public static string AppVersion
    {
        get { return PlayerPrefs.GetString(APP_VERSION, "0"); }
        set { PlayerPrefs.SetString(APP_VERSION, value); }
    }
}