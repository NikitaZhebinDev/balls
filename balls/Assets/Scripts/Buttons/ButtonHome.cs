using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ButtonHome : MonoBehaviour
{




    public GameObject PausePanel;
    private Animator animatorPausePanelAppearance;


    private float previousTimeScale;



    void Start()
    {
        animatorPausePanelAppearance = PausePanel.GetComponent<Animator>();
    }



    public void PressHomeBtnAnim()
    {
        //animatorPausePanelAppearance.Play("BtnHomeAppearance", animatorPausePanelAppearance.GetLayerIndex("Base Layer"));
        SceneManager.LoadScene(0, LoadSceneMode.Single);

        // To Show Interstitial Ad
        PlayerPrefs.SetString("CameForAd", "Yes");
    }



}
