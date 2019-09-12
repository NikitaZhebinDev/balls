using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioThrowBall : MonoSingleton<AudioThrowBall> {


    public AudioSource audioThrowBall;


    public void PlaySoundThrowBall()
    {
        if (PlayerPrefs.GetString("Sound").CompareTo("On") == 0)
            audioThrowBall.PlayOneShot(audioThrowBall.clip);
    }


}
