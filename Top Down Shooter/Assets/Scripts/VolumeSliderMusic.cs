using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderMusic : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;

    private void Start()
    {
        SoundManager.instance.MusicSource.volume = PlayerPrefsManager.MusicVolume;
        musicVolumeSlider.value = SoundManager.instance.MusicSource.volume * 10f;
    }

    public void OnMusicVolumeChange()
    {
        SoundManager.instance.MusicSource.volume = musicVolumeSlider.value / 10f;
        PlayerPrefsManager.MusicVolume = SoundManager.instance.MusicSource.volume;

        PlayerPrefs.Save();
    }
}