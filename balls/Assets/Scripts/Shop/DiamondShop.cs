using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiamondShop : MonoSingleton<DiamondShop> {

    public Text diamondsCount;

    public GameObject Diamonds;

    public GameObject particleSystemBuy;

    public GameObject[] bttnsPrices; // don't include the first ball price


    



    void Start()
    {

        if (PlayerPrefs.GetInt("DiamondCount") > 0)
        {
            diamondsCount.text = PlayerPrefs.GetInt("DiamondCount").ToString();
        }
        else
        {
            diamondsCount.text = "0";
        }



        for (int i = 0; i < bttnsPrices.Length; i++) {

            if (PlayerPrefs.GetString("Ball_" + i + "_Purchased").CompareTo("Yes") == 0)
            {
                bttnsPrices[i].SetActive(false);
            }
            else // we purchased this ball earlier
            {
                bttnsPrices[i].SetActive(true);
            }
        }


    }












    public void BuyBall(int btnID)
    {
        int price = 0;



        if (btnID <= 14) { price = 10; } // Standart
        else if (btnID > 14 && btnID <= 30) { price = 20; } // Rare
        else if (btnID > 30 && btnID <= 46) { price = 30; } // Gold
        else if (btnID > 46 && btnID <= 62) { price = 50; } // Epic




        if (price <= PlayerPrefs.GetInt("DiamondCount"))
        {
            bttnsPrices[btnID].SetActive(false);
            ChooseBall.Instance.ChooseBallIndex(btnID + 1);


            PlayerPrefs.SetString("Ball_" + btnID + "_Purchased", "Yes");


            int currentDCount = PlayerPrefs.GetInt("DiamondCount");


            PlayerPrefs.SetInt("DiamondCount", (currentDCount - price));
            diamondsCount.text = PlayerPrefs.GetInt("DiamondCount").ToString();

            Diamonds.SetActive(false);
            Diamonds.SetActive(true);

            if (!particleSystemBuy.activeSelf)
                StartCoroutine(TurnOnPSystem(btnID));

            AudioBuyBall.Instance.PlaySoundBuyBall();
        }
        else
        {
            // we haven't enough money!

            Diamonds.SetActive(false);
            Diamonds.SetActive(true);

            AudioCancelPurchase.Instance.PlaySoundCancelPurchase();

            //if (!particleSystemBuy.activeSelf)
               // StartCoroutine(TurnOnPSystem(btnID));
        }


    }
    






    private IEnumerator TurnOnPSystem(int BtnID)
    {
        particleSystemBuy.transform.position = 
            new Vector3(bttnsPrices[BtnID].transform.position.x, bttnsPrices[BtnID].transform.position.y, particleSystemBuy.transform.position.z);
        particleSystemBuy.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        particleSystemBuy.SetActive(false);
    }







}
