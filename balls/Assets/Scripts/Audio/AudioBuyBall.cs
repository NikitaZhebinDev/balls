using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBuyBall : MonoSingleton<AudioBuyBall> {


    public AudioSource audioBuyBall;


    public void PlaySoundBuyBall()
    {
        if (PlayerPrefs.GetString("Sound").CompareTo("On") == 0)
            audioBuyBall.PlayOneShot(audioBuyBall.clip);
    }

}
