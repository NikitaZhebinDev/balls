using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private const string FACEBOOK_URL = "https://www.facebook.com/N3ken/";

   


    public void OnPlayClick()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void OnRateClick()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.nikzhebindev.balls");
    }

    public void SoundClick()
    {

    }

    public void TutorialClick()
    {

    }

    

}