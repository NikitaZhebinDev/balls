using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PauseMenu : MonoSingleton<PauseMenu>
{

    public bool isPause;


    public GameObject PausePanel;
    private Animator animatorPausePanelAppearance;


    private float previousTimeScale;


    public GameObject CheckPointText;


	void Start () {
        previousTimeScale = 1.0f;

        isPause = false;
        PausePanel.SetActive(false);

        animatorPausePanelAppearance = PausePanel.GetComponent<Animator>();
    }








    public Text pauseText, continueTextW, continueTextB, restartTextW, restartTextB;



    public void PauseOn()
    {
        if (!isPause)
        {
            CheckPointText.SetActive(true);
            previousTimeScale = Time.timeScale;
            isPause = true;
            //Time.timeScale = 0;
            PausePanel.SetActive(true);


            ////////////////////////////////////////////////////////////////

            if (PlayerPrefs.GetString("Language").CompareTo("RUS") == 0)
            {
                pauseText.text = "ПАУЗА";
                continueTextW.text = "Продолжить";
                continueTextB.text = "Продолжить";
                restartTextW.text = "Заново";
                restartTextB.text = "Заново";
            }
            else
            {
                pauseText.text = "PAUSE";
                continueTextW.text = "Continue";
                continueTextB.text = "Continue";
                restartTextW.text = "Restart";
                restartTextB.text = "Restart";
            }

            ////////////////////////////////////////////////////////////////


            animatorPausePanelAppearance.Play("PausePanelAppearanceAnim", animatorPausePanelAppearance.GetLayerIndex("Base Layer"));
            StartCoroutine(StopTime());

        }
    }


    private IEnumerator StopTime()
    {
        yield return new WaitForSeconds(1.0f);

        Time.timeScale = 0.0f;
    }



    public void PauseOff()
    {
        if (isPause)
        {
            CheckPointText.SetActive(false);
            Time.timeScale = previousTimeScale;

            // HERE PLAY REVERSE ANIMATION
            animatorPausePanelAppearance.Play("PausePanelDisappearanceAnim", animatorPausePanelAppearance.GetLayerIndex("Base Layer"));


            StartCoroutine(HidePausePanel());

       
        }
    }



    private IEnumerator HidePausePanel()
    {
        yield return new WaitForSeconds(0.5f);
        
        PausePanel.SetActive(false);
        isPause = false;
    }



}
