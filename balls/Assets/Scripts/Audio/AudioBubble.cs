using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBubble : MonoSingleton<AudioBubble> {


    public AudioSource audioBubble;


    public void PlaySoundBubble()
    {
        if (PlayerPrefs.GetString("Sound").CompareTo("On") == 0)
            audioBubble.PlayOneShot(audioBubble.clip);
    }

}
