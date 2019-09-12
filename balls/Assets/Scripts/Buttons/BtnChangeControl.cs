using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BtnChangeControl : MonoBehaviour {

    public GameObject slideDown, slideUp;




    private void Start()
    {
        if (PlayerPrefs.GetString("Sliding").CompareTo("Down") != 0 && PlayerPrefs.GetString("Sliding").CompareTo("Up") != 0)
            PlayerPrefs.SetString("Sliding", "Down");


        if (PlayerPrefs.GetString("Sliding").CompareTo("Down") == 0)
        {
            slideUp.SetActive(false);
            slideDown.SetActive(true);
        }
        else
        {
            slideUp.SetActive(true);
            slideDown.SetActive(false);
        }


    }




    public void SetSliding()
    {
        if (slideDown.activeSelf)
        {
            slideUp.SetActive(true);
            slideDown.SetActive(false);
            PlayerPrefs.SetString("Sliding", "Up");
        }
        else if (slideUp.activeSelf)
        {
            slideUp.SetActive(false);
            slideDown.SetActive(true);
            PlayerPrefs.SetString("Sliding", "Down");
        }
    }



}
