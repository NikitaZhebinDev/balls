using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnBack : MonoSingleton<BtnBack> {

	

    public void BackToMenu()
    {
        if (PlayerPrefs.GetInt("OpenShopFromScene") == 0)
        {
            PlayerPrefs.SetString("CameForAd", "Yes");
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("OpenShopFromScene"), LoadSceneMode.Single);
    }



}
