using UnityEngine;

public class SoundManager : MonoBehaviour

{
    public static SoundManager instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private bool isAudioEnabled = true;

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

    private void Start()
    {
        isAudioEnabled = PlayerPrefsManager.IsAudioEnabled;
        musicSource.volume = PlayerPrefsManager.MusicVolume;
        sfxSource.volume = PlayerPrefsManager.SfxVolume;
        ToggleAudioSources();
    }

    public AudioSource MusicSource
    {
        get { return musicSource; }
    }

    public AudioSource SfxSource
    {
        get { return sfxSource; }
    }

    public void ToggleGlobalAudio()
    {
        isAudioEnabled = !isAudioEnabled;
        PlayerPrefsManager.IsAudioEnabled = isAudioEnabled;
        PlayerPrefs.Save();

        ToggleAudioSources();
    }

    private void ToggleAudioSources() //TODO make music play continuosly
    {
        if (isAudioEnabled)
        {
            musicSource.enabled = true;
            sfxSource.enabled = true;
        }
        else if (!isAudioEnabled)
        {
            musicSource.enabled = false;
            sfxSource.enabled = false;
        }
    }

    public void PlayOneShotSFX(AudioClip clip)
    {
        if (isAudioEnabled)
        {
            SfxSource.PlayOneShot(clip);
        }
    }
}