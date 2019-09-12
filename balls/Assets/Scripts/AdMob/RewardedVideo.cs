using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;


public class RewardedVideo : MonoBehaviour {

    private const string appId = "ca-app-pub-5033052294993457~4898552824";

    private RewardBasedVideoAd rewardBasedVideo;
    private const string RewardId =  "ca-app-pub-5033052294993457/3925489722"; // "ca-app-pub-3940256099942544/5224354917"; // tested


    public bool btnRewardWasPressed;

    public GameObject GameRewardPanel;



    public void Start()
    {
        btnRewardWasPressed = false;

        // Initialize the Google Mobile Ads SDK.
        //MobileAds.Initialize(appId);

        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;



        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;



        this.RequestRewardBasedVideo();



        if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
        {
            textTop.text = "Смотреть";
            textDown.text = "видео";
        }
        else
        {
            textTop.text = "Watch";
            textDown.text = "a video";
        }

    }





    private void Update()
    {
        if (rewardBasedVideo.IsLoaded() && btnRewardWasPressed)
        {
            btnRewardWasPressed = false;
            rewardBasedVideo.Show();
        }

    }






    private void RequestRewardBasedVideo()
    {

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder()
            //.AddTestDevice(AdRequest.TestDeviceSimulator)
            //.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            //.AddKeyword("game")
        .Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, RewardId);

    }





    public Text textTop, textDown;

    public void ChangeText()
    {
        if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
        {
            if (textTop.text.CompareTo("Смотреть") == 0)
            {
                textTop.text = "Раз";
                textDown.text = "в 30 мин";
            }
            else
            {
                textTop.text = "Смотреть";
                textDown.text = "видео";
            }
        }
        else
        {
            if (textTop.text.CompareTo("Watch") == 0)
            {
                textTop.text = "Once";
                textDown.text = "in 30 mins";
            }
            else
            {
                textTop.text = "Watch";
                textDown.text = "a video";
            }
        }



    }


    public void ShowAdRewardVideo()
    {
        btnRewardWasPressed = true;
    }





    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        //string type = args.Type;
        //double amount = args.Amount;
        //MonoBehaviour.print(
        //    "HandleRewardBasedVideoRewarded event received for "
        //                  + amount.ToString() + " " + type);

        GameRewardPanel.SetActive(true);

        int diamondCount = PlayerPrefs.GetInt("DiamondCount");
        PlayerPrefs.SetInt("DiamondCount", (diamondCount + 5));

        // Update Text in Shop
        DiamondShop.Instance.diamondsCount.text = PlayerPrefs.GetInt("DiamondCount").ToString();
        
    }






    public void OnDestroy()
    {
        rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
    }


}
