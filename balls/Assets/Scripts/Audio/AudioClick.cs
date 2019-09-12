using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClick : MonoBehaviour {


    public AudioSource audioClick;


    public void PlaySoundClick()
    {
        if (PlayerPrefs.GetString("Sound").CompareTo("On") == 0)
            audioClick.PlayOneShot(audioClick.clip);
    }


}
