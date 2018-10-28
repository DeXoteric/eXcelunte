using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsCanvas;

    public void ShowSettings()
    {
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void HideSettings()
    {
        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }
}