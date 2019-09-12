using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class QuitGameBanner : MonoBehaviour {

    private const string appId = "ca-app-pub-5033052294993457~4898552824";

    BannerView quitGameBanner;
    private const string QuitGameBannerId =  "ca-app-pub-5033052294993457/4078243407"; // "ca-app-pub-3940256099942544/6300978111"; // tested






    void Start()
    {

        if (PlayerPrefs.GetString("no_ads").CompareTo("true") != 0)
            this.ShowBanner();


    }






    public void ShowBanner()
    {


        if (this.quitGameBanner == null)
        {

            this.quitGameBanner = new BannerView(QuitGameBannerId, AdSize.Leaderboard, AdPosition.Center);

            AdRequest request = new AdRequest.Builder()
                //.AddTestDevice(AdRequest.TestDeviceSimulator)
                //.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
                //.AddKeyword("game")
                //.TagForChildDirectedTreatment(false)
                //.AddExtra("color_bg", "9B30FF")
                .Build();

            // Load a banner ad.
            this.quitGameBanner.LoadAd(request);
        }
    }






}
