using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoSingleton<GameOver>
{

    public GameObject gameOverPanel;

    public Text ScoreText;
    public Text BestScore;

    public Text gameOverText, btnReplayWhite, btnReplayBlack;


    public void PlayGameOverAnim()
    {
        if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
        {
            gameOverText.text = "Конец Игры";
            btnReplayWhite.text = "Играть";
            btnReplayBlack.text = "Играть";
        }
        else
        {
            gameOverText.text = "Game Over";
            btnReplayWhite.text = "Replay";
            btnReplayBlack.text = "Replay";
        }


            gameOverPanel.SetActive(true);
        ScoreText.text = Ball.Instance.scoreText.text;


        if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
            BestScore.text = "Рекорд: " + PlayerPrefs.GetInt("BestScore").ToString();
        else
            BestScore.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();


        PlayerPrefs.SetInt("SavedAmountBalls", 1);
        PauseMenu.Instance.isPause = true;
        OneMoreChanceAd.Instance.OneMoreChancePanel.SetActive(false);
    }



}
