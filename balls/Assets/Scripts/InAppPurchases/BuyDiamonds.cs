using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyDiamonds : MonoBehaviour {

    public GameObject PurchasedDiamondsPanel;
    public Text AmountText;


    public void GetDiamonds(int money)
    {
        int diamondCount = PlayerPrefs.GetInt("DiamondCount");
        PlayerPrefs.SetInt("DiamondCount", (diamondCount + money));

        PurchasedDiamondsPanel.SetActive(true);
        if (money != 1000)
            AmountText.text = "+" + money.ToString();
        else
            AmountText.text = "+1K";
    }

}
