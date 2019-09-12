using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;


public class OneMoreChanceAd : MonoSingleton<OneMoreChanceAd> {

    private const string appId = "ca-app-pub-5033052294993457~4898552824";

    public RewardBasedVideoAd rewardBasedVideo;
    private const string RewardId =  "ca-app-pub-5033052294993457/3570266505"; // "ca-app-pub-3940256099942544/5224354917"; // tested



    public GameObject OneMoreChancePanel;




    public bool RewardWasOrdered;




    public void Start()
    {
        RewardWasOrdered = false;

        // Initialize the Google Mobile Ads SDK.
        //MobileAds.Initialize(appId);

        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;



        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
       


        this.RequestRewardBasedVideo();

    }





    public void Update()
    {
        if (rewardBasedVideo.IsLoaded() && RewardWasOrdered)
        {
            RewardWasOrdered = false;
            rewardBasedVideo.Show();
        }
    }




    public void OrderAd()
    {
        RewardWasOrdered = true;
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









    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        //string type = args.Type;
        //double amount = args.Amount;
        //MonoBehaviour.print(
        //    "HandleRewardBasedVideoRewarded event received for "
        //                  + amount.ToString() + " " + type);




        // just RESTART the game with CURRENT SCORE
        PlayerPrefs.SetString("ContinueGameReward", "Yes");
        PlayerPrefs.SetInt("ContinueGameRewardScore", Ball.Instance.score);

        // restart
        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }









    public void ShowOneMoreChancePanel()
    {
        OneMoreChancePanel.SetActive(true);
    }

    public void HideOneMoreChancePanel()
    {
        OneMoreChancePanel.SetActive(false);
        DestroyAllBlocksAndActiveGameOver();
    }






    public void DestroyAllBlocksAndActiveGameOver()
    {

        Block[] blocks = GameObject.FindObjectsOfType<Block>();

        foreach (Block block in blocks)
        {
            block.DestroyBlock();
            block.DestroyGetBall();
        }


        //PlayerPrefs.SetInt("SavedAmountBalls", 1);


        GameOver.Instance.PlayGameOverAnim();
        AudioBlockDestruction.Instance.PlaySoundBlockDestruction();

    }








    public void OnDestroy()
    {
        rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
    }





}
