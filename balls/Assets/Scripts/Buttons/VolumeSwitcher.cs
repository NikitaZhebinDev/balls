using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSwitcher : MonoBehaviour
{


    public GameObject volumeOn;
    public GameObject volumeOff;


    private void Start()
    {
        // set volume from a value from our database
        if(PlayerPrefs.GetString("Sound").CompareTo("On") != 0 && PlayerPrefs.GetString("Sound").CompareTo("Off") != 0)
        PlayerPrefs.SetString("Sound", "On");


        if (PlayerPrefs.GetString("Sound").CompareTo("On") == 0)
        {
            volumeOff.SetActive(false);
            volumeOn.SetActive(true);
        }
        else
        {
            volumeOff.SetActive(true);
            volumeOn.SetActive(false);
        }

    }



    public void TurnVolume()
    {
        if (volumeOn.activeSelf)
        {
            volumeOff.SetActive(true);
            volumeOn.SetActive(false);
            PlayerPrefs.SetString("Sound", "Off");
        }
        else if (volumeOff.activeSelf)
        {
            volumeOff.SetActive(false);
            volumeOn.SetActive(true);
            PlayerPrefs.SetString("Sound", "On");
        }
    }

    


}
