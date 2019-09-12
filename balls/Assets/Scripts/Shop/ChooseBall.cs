using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChooseBall : MonoSingleton<ChooseBall> {


    public GameObject[] imagesChoosenButtons;


    public int choosenBall;


    public GameObject[] imagesChoosenBalls;



    private void Start()
    {
        Time.timeScale = 1.0f;

        if (PlayerPrefs.GetInt("ChoosenBall") > 0)
        {
            choosenBall = PlayerPrefs.GetInt("ChoosenBall");
        }
        else
        {
            choosenBall = 0;
        }

        imagesChoosenButtons[choosenBall].SetActive(true);
        imagesChoosenBalls[choosenBall].SetActive(true);

        for (int i = 0; i < imagesChoosenButtons.Length; i++)
        {
            if (i != choosenBall)
            {
                imagesChoosenButtons[i].SetActive(false);
                imagesChoosenBalls[i].SetActive(false);
            }
        }

    }




    public void ChooseBallIndex(int item)
    {
        imagesChoosenButtons[item].SetActive(true);
        imagesChoosenBalls[item].SetActive(true);

        for (int i = 0; i < imagesChoosenButtons.Length; i++)
        {
            if (i != item)
            {
                imagesChoosenButtons[i].SetActive(false);
                imagesChoosenBalls[i].SetActive(false);
            }
        }

        PlayerPrefs.SetInt("ChoosenBall", item);
    }






}
