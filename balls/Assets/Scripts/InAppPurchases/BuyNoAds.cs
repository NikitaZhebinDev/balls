using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyNoAds : MonoBehaviour {


    //public GameObject NoAdsPanel;


    void Start()
    {

        // check if the product is already bought
        // ..........



        /*if (PlayerPrefs.GetString("no_ads").CompareTo("true") == 0)
        {
            NoAdsPanel.SetActive(false);
        }
        else
        {
            NoAdsPanel.SetActive(true);
        }*/

    }





    public void SetNoAds()
    {
        PlayerPrefs.SetString("no_ads", "true");
        ShowAd.Instance.shopBanner.Destroy();
    }






}