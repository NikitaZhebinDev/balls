using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCancelPurchase : MonoSingleton<AudioCancelPurchase> {


    public AudioSource audioCancelPurchase;


    public void PlaySoundCancelPurchase()
    {
        if (PlayerPrefs.GetString("Sound").CompareTo("On") == 0)
            audioCancelPurchase.PlayOneShot(audioCancelPurchase.clip);
    }

}
