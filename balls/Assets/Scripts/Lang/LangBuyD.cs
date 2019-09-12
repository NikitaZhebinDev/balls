using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LangBuyD : MonoBehaviour {


    public Text shopText, closeW, closeB;


	void Start () {

        if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
        {
            shopText.text = "Магазин";
            closeW.text = closeB.text = "Закрыть";
        }
        else
        {
            shopText.text = "Shop";
            closeW.text = closeB.text = "Close";
        }

    }


}
