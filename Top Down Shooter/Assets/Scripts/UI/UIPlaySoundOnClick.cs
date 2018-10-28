using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlaySoundOnClick : MonoBehaviour {

    [SerializeField] private AudioClip buttonSFX;

    public void PlaySoundOnClick()
    {
        SoundManager.instance.PlayOneShotSFX(buttonSFX);
    }
}
