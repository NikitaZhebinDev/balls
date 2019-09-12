using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBlockDestruction : MonoSingleton<AudioBlockDestruction> {


    public AudioSource audioBlockDestruction;


    public void PlaySoundBlockDestruction()
    {
        if (PlayerPrefs.GetString("Sound").CompareTo("On") == 0)
            audioBlockDestruction.PlayOneShot(audioBlockDestruction.clip);
    }


}
