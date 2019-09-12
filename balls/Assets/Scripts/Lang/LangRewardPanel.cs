using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LangRewardPanel : MonoBehaviour {


    public Text rewardText, gotItW, gotItB;


	void Start () {

        if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
        {
            rewardText.text = "Награда: ";
            gotItW.text = gotItB.text = "Получить!";
        }
        else
        {
            rewardText.text = "Your reward: ";
            gotItW.text = gotItB.text = "Got it!";
        }

    }
	

}
