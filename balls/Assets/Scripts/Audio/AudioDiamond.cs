using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDiamond : MonoSingleton<AudioDiamond> {


    public AudioSource audioDiamond;


    public void PlaySoundDiamond()
    {
        if (PlayerPrefs.GetString("Sound").CompareTo("On") == 0)
            audioDiamond.PlayOneShot(audioDiamond.clip);
    }

}
