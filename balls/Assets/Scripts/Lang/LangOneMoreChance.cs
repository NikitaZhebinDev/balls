using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LangOneMoreChance : MonoBehaviour {


    public Text continueText, oneMoreChanceText, yesWatchAdText, nopeText;



	void Start () {

        if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
        {
            continueText.text = "Продолжить?";
            oneMoreChanceText.text = "Ещё Один Шанс";
            yesWatchAdText.text = "ДА, СМОТРЕТЬ AD";
            nopeText.text = "Нет";
        }
        else
        {
            continueText.text = "Continue?";
            oneMoreChanceText.text = "One More Chance";
            yesWatchAdText.text = "YES, WATCH AD";
            nopeText.text = "Nope";
        }

    }
	
	

}
