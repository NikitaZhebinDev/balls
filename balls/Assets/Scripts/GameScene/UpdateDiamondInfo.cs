using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateDiamondInfo : MonoSingleton<UpdateDiamondInfo>
{
    
    public GameObject ImageDiamond;

    public Text countDiamonds;

    public GameObject TextCountDiamonds;



    public void UpdateDInfo()
    {
        countDiamonds.text = PlayerPrefs.GetInt("DiamondCount").ToString();
    }


}
