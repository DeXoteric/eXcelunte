using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderSFX : MonoBehaviour
{
    [SerializeField] private Slider sfxVolumeSlider;

    private void Start()
    {
        SoundManager.instance.SfxSource.volume = PlayerPrefsManager.SfxVolume;
        sfxVolumeSlider.value = SoundManager.instance.SfxSource.volume * 10f;
    }

    public void OnSfxVolumeChange()
    {
        SoundManager.instance.SfxSource.volume = sfxVolumeSlider.value / 10f;
        PlayerPrefsManager.SfxVolume = SoundManager.instance.SfxSource.volume;

        PlayerPrefs.Save();
    }
}