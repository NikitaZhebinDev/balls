using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LangGameExit : MonoBehaviour {


    public Text gameExitText, yesW, yesB, noW, noB;


	void Start () {

        if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
        {
            gameExitText.text = "Вы хотите выйти?";
            yesW.text = yesB.text = "Да";
            noW.text = noB.text = "Нет";
        }
        else
        {
            gameExitText.text = "Do you want to exit?";
            yesW.text = yesB.text = "Yes";
            noW.text = noB.text = "No";
        }

    }
	

}
