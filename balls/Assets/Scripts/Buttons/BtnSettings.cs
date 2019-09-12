using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSettings : MonoBehaviour {


    public GameObject panelSettings;
    //public Image image;
    public Text removeAdsText;


    public void GetSettings()
    {
        if (!panelSettings.activeSelf)
        {
            panelSettings.SetActive(true);

            gameObject.SetActive(false);
            gameObject.SetActive(true);

            //image.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));

            if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
            {
                removeAdsText.text = "Убрать Рекламу";
            }
            else
            {
                removeAdsText.text = "Remove Ads";
            }

        }
        else
        {
            panelSettings.SetActive(false);
        }
    }


}
