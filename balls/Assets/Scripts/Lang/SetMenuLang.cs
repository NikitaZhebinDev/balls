using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetMenuLang : MonoSingleton<SetMenuLang> {

    public Text btnPlay, btnShop, btnRate;

    public Text btnLevels;

    public Text removeAdsText;


	void Start () {


        if (PlayerPrefs.GetString("Language").CompareTo("ENG") == 0)
        {
            btnPlay.text = "Play";
            btnShop.text = "Shop";
            btnRate.text = "Rate it!";
            btnLevels.text = "Levels";
        }
        else if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
        {
            btnPlay.text = "Играть";
            btnShop.text = "Лавка";
            btnRate.text = "Оцените!";
            btnLevels.text = "Уровни";
        }
        else
        {
            btnPlay.text = "Play";
            btnShop.text = "Shop";
            btnRate.text = "Rate it!";
            btnLevels.text = "Levels";
        }






        if (PlayerPrefs.GetString("Language").CompareTo("ENG") == 0)
            DiamondMenu.Instance.textBest.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();
        else if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
            DiamondMenu.Instance.textBest.text = "Рекорд: " + PlayerPrefs.GetInt("BestScore").ToString();
        else
            DiamondMenu.Instance.textBest.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();




    }
	




    public void UpdateMenuLang()
    {
        if (PlayerPrefs.GetString("Language").CompareTo("ENG") == 0)
        {
            btnPlay.text = "Play";
            btnShop.text = "Shop";
            btnRate.text = "Rate it!";
            btnLevels.text = "Levels";
            removeAdsText.text = "Remove Ads";
        }
        else if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
        {
            btnPlay.text = "Играть";
            btnShop.text = "Лавка";
            btnRate.text = "Оцените!";
            btnLevels.text = "Уровни";
            removeAdsText.text = "Убрать Рекламу";
        }
        else
        {
            btnPlay.text = "Play";
            btnShop.text = "Shop";
            btnRate.text = "Rate it!";
            btnLevels.text = "Levels";
            removeAdsText.text = "Remove Ads";
        }



        if (PlayerPrefs.GetString("Language").CompareTo("ENG") == 0)
            DiamondMenu.Instance.textBest.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();
        else if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
            DiamondMenu.Instance.textBest.text = "Рекорд: " + PlayerPrefs.GetInt("BestScore").ToString();
        else
            DiamondMenu.Instance.textBest.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();


    }


	

}
