using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondMovement : MonoBehaviour {



    private GameObject targetPos;



    void Start()
    {
        targetPos = Ball.Instance.diamondTargetPos;
    }



    void Update () {
     
        if (Ball.Instance.moveDiamond && transform.position.y < targetPos.transform.position.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos.transform.position, Time.deltaTime * 3);
        }
        if(Ball.Instance.moveDiamond && transform.position.y >= Ball.Instance.bestScoreText.transform.position.y)
        {
            UpdateDiamondInfo.Instance.ImageDiamond.SetActive(false);
            UpdateDiamondInfo.Instance.ImageDiamond.SetActive(true);

            UpdateDiamondInfo.Instance.TextCountDiamonds.SetActive(false);
            UpdateDiamondInfo.Instance.TextCountDiamonds.SetActive(true);


            PlayerPrefs.SetInt("DiamondCount", (PlayerPrefs.GetInt("DiamondCount") + 1));
            UpdateDiamondInfo.Instance.countDiamonds.text = PlayerPrefs.GetInt("DiamondCount").ToString();
            

            Ball.Instance.moveDiamond = false;
            Destroy(gameObject);
        }


        
	}


    

}
