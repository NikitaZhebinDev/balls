using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoSingleton<Restart> {



    public void RestartGame()
    {
        PlayerPrefs.SetInt("SavedAmountBalls", 1);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }



}
