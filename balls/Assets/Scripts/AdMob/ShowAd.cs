using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;



public class ShowAd : MonoSingleton<ShowAd> {

    private const string appId = "ca-app-pub-5033052294993457~4898552824";

    public BannerView shopBanner;
    private const string ShopBanner =  "ca-app-pub-5033052294993457/8287682237";  // "ca-app-pub-3940256099942544/6300978111"; // tested

    InterstitialAd interstitial;
    private const string GameToMenu =  "ca-app-pub-5033052294993457/7709097739";  // "ca-app-pub-3940256099942544/1033173712"; // tested



    public GameObject QuitGamePanel;

    


    public void Start()
    {
        

        if (PlayerPrefs.GetString("no_ads").CompareTo("true") != 0)
        {
            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(appId);
        
            this.ShowBanner();


            this.ShowInterstitial();
        }


    }





    private void Update()
    {
        if (PlayerPrefs.GetString("no_ads").CompareTo("true") != 0)
        {
            if (PlayerPrefs.GetString("CameForAd").CompareTo("Yes") == 0) // and IF we came from GAME or SHOP
            {

                if (this.interstitial.IsLoaded())
                {
                    PlayerPrefs.SetString("CameForAd", "No");
                    this.interstitial.Show();
                }               

            }
        }


        // If KeyCode *BACK* was pressed  SHOW QUIT GAME PANEL
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.QuitGamePanel.SetActive(true);
            //this.shopBanner.Destroy();
            //ShowLeaderBanner();
        }
        

    }





    public void ShowBanner()
    {
        this.shopBanner = new BannerView(ShopBanner, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder()
            //.AddTestDevice(AdRequest.TestDeviceSimulator)
            //.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            .AddKeyword("game")
            //.TagForChildDirectedTreatment(false)
            //.AddExtra("color_bg", "9B30FF")
            .Build();

        // Load a banner ad.
        this.shopBanner.LoadAd(request);

    }









    public void ShowInterstitial()
    {

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(GameToMenu);

        AdRequest request = new AdRequest.Builder()
            //.AddTestDevice(AdRequest.TestDeviceSimulator)
            //.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            //.AddKeyword("game")
            //.TagForChildDirectedTreatment(false)
            //.AddExtra("color_bg", "9B30FF")
            .Build();

        this.interstitial.LoadAd(request);

    }










    private void OnDestroy()
    {
        PlayerPrefs.SetString("CameForAd", "No");
    }





}
