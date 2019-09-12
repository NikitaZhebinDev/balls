using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BtnTimeScale : MonoSingleton<BtnTimeScale> {


    public Text timeScapeText;



	void Start () {
        timeScapeText.text = "X2";
    }
	



    public void TimeScaleUp()
    {
        if (Time.timeScale == 2)
        {
            Time.timeScale = 4;
            timeScapeText.text = "X4";
        }
        else if (Time.timeScale == 4)
        {
            Time.timeScale = 6;
            timeScapeText.text = "X6";
        }
        else if(Time.timeScale == 6)
        {
            Time.timeScale = 8;
            timeScapeText.text = "X8";
        }
        else if (Time.timeScale == 8)
        {
            Time.timeScale = 2;
            timeScapeText.text = "X2";
        }
    }



	
}
