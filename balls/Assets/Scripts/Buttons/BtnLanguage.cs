using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnLanguage : MonoBehaviour {




	void Start () {

        if (PlayerPrefs.GetString("Language").CompareTo("RUS") != 0 
            && PlayerPrefs.GetString("Language").CompareTo("ENG") != 0)
        {

            if (Application.systemLanguage.Equals(SystemLanguage.Russian))
            {
                PlayerPrefs.SetString("Language", "RUS");
            }
            else if (Application.systemLanguage.Equals(SystemLanguage.English))
            {
                PlayerPrefs.SetString("Language", "ENG");
            }

        }

	}






    public void SetLanguageRUS()
    {
        PlayerPrefs.SetString("Language", "RUS");
        SetMenuLang.Instance.UpdateMenuLang();
    }


    public void SetLanguageENG()
    {
        PlayerPrefs.SetString("Language", "ENG");
        SetMenuLang.Instance.UpdateMenuLang();
    }






}
