using UnityEngine;

public class AppVersionManager : MonoBehaviour
{
    [Tooltip("Check this if you want to reset player HighScore when new App version is installed.")]
    [SerializeField] private bool resetScore = false;

    private string newAppVersion, currentAppVersion;

    private void Awake()
    {
        newAppVersion = Application.version;
        currentAppVersion = PlayerPrefsManager.AppVersion;

        if (!string.Equals(newAppVersion, currentAppVersion) && resetScore)
        {
            PlayerPrefs.DeleteKey(PlayerPrefsManager.HIGH_SCORE);

            resetScore = false;
        }

        PlayerPrefsManager.AppVersion = newAppVersion;
    }
}