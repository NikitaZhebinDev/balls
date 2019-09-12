using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonShop : MonoBehaviour {



    public void OpenShop()
    {
        if(SceneManager.GetActiveScene().name.CompareTo("Menu") == 0)
        {
            PlayerPrefs.SetInt("OpenShopFromScene", 0);
        }
        else
        {
            PlayerPrefs.SetInt("OpenShopFromScene", 1);
        }
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }



}
