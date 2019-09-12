using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Replay : MonoSingleton<Replay> {


    public void ReplayGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }


}
