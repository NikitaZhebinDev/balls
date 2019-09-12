using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBlockCollision : MonoSingleton<AudioBlockCollision> {


    public AudioSource audioBlockCollision;

    bool startCount;

    public float delayTime;
    float timer;


    private void Start()
    {
        timer = 0;
        startCount = false;
    }

    private void Update()
    {

        if (startCount)
        {
            timer += Time.deltaTime;
        }

        if (timer >= delayTime)
        {
            timer = 0;
            startCount = false;
        }

    }


    public void PlaySoundBlockCollision()
    {
        if (PlayerPrefs.GetString("Sound").CompareTo("On") == 0)
            if (!startCount)
            {
                audioBlockCollision.PlayOneShot(audioBlockCollision.clip);
                startCount = true;
            }
    }


}
