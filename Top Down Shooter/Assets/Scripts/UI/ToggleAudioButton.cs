using UnityEngine;
using UnityEngine.UI;

public class ToggleAudioButton : MonoBehaviour
{
    [SerializeField] private GameObject toggleAudioButton;
    [SerializeField] private Sprite[] audioToggleSprites;

    private void OnEnable()
    {
        ChangeSprite();
    }

    private void Start()
    {
        ChangeSprite();
    }

    public void ToggleAudio()
    {
        SoundManager.instance.ToggleGlobalAudio();
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        if (PlayerPrefsManager.IsAudioEnabled)
        {
            toggleAudioButton.GetComponent<Image>().sprite = audioToggleSprites[0];
        }
        else if (!PlayerPrefsManager.IsAudioEnabled)
        {
            toggleAudioButton.GetComponent<Image>().sprite = audioToggleSprites[1];
        }
    }
}