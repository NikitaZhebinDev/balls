using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class CancelQuitGame : MonoSingleton<CancelQuitGame> {

    public GameObject quitGamePanel;

    private const string appId = "ca-app-pub-5033052294993457~4898552824";

    public BannerView quitBanner;
    private const string QuitBanner =  "ca-app-pub-5033052294993457/4078243407"; // "ca-app-pub-3940256099942544/6300978111"; // tested








    void Start()
    {

        if (PlayerPrefs.GetString("no_ads").CompareTo("true") != 0)
        {
            this.ShowLeaderBanner();
        }

    }



    private void Update()
    {
        if (quitGamePanel.activeSelf && quitBanner != null)
        {
            if (PlayerPrefs.GetString("no_ads").CompareTo("true") != 0)
                quitBanner.Show();
        }
    }




    public void ShowLeaderBanner()
    {


        if (this.quitBanner == null)
        {

            this.quitBanner = new BannerView(QuitBanner, AdSize.MediumRectangle, AdPosition.Top);

            AdRequest request = new AdRequest.Builder()
                //.AddTestDevice(AdRequest.TestDeviceSimulator)
                //.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
                //.AddKeyword("game")
                //.TagForChildDirectedTreatment(false)
                //.AddExtra("color_bg", "9B30FF")
                .Build();

            // Load a banner ad.
            this.quitBanner.LoadAd(request);
        }
    }









    public void CancelQuit()
    {        
        quitBanner.Hide();
        quitGamePanel.SetActive(false);
    }








}
