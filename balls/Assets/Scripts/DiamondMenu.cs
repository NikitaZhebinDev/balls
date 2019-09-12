using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiamondMenu : MonoSingleton<DiamondMenu> {


    public Text diamondsCount;

    public Text textBest;




    void Start()
    {


        Time.timeScale = 1.0f;

        //PlayerPrefs.SetInt("DiamondCount", 100); // !!!!!!!!!!

        //PlayerPrefs.DeleteAll(); // !!!!!!!!!!


        if (PlayerPrefs.GetInt("DiamondCount") > 0)
        {
            diamondsCount.text = PlayerPrefs.GetInt("DiamondCount").ToString();
        }
        else
        {
            diamondsCount.text = "0";
        }

        if (PlayerPrefs.GetString("Language").CompareTo("ENG") == 0)
            textBest.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();
        else if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
            textBest.text = "Рекорд: " + PlayerPrefs.GetInt("BestScore").ToString();
        else
            textBest.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();
    }




    public void UpdateMenuDiamonds()
    {
        if (PlayerPrefs.GetInt("DiamondCount") > 0)
        {
            diamondsCount.text = PlayerPrefs.GetInt("DiamondCount").ToString();
        }
        else
        {
            diamondsCount.text = "0";
        }
    }




}
