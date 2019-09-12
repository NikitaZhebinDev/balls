using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TipLanguage : MonoBehaviour {


    public Text tipText;


	void Start () {

        if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
        {
            if (PlayerPrefs.GetString("Sliding").CompareTo("Down") == 0)
                tipText.text = "Потяните вниз";
            else
                tipText.text = "Потяните вверх";
        }
        else
        {
            if (PlayerPrefs.GetString("Sliding").CompareTo("Down") == 0)
                tipText.text = "Slide down to shoot";
            else
                tipText.text = "Slide up to shoot";
        }

    }
	

}
