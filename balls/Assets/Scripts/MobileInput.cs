using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobileInput : MonoSingleton<MobileInput>
{

    public bool tap,release,hold;
    public Vector2 swipeDelta;
    

    private Vector2 initialPosition;

    public bool CancelPoolInput;




    private void Start()
    {
        CancelPoolInput = false;
    }



    private void Update()
    {
        if (!PauseMenu.Instance.isPause && !OneMoreChanceAd.Instance.OneMoreChancePanel.activeSelf)
        {
            release = tap = false;
            swipeDelta = Vector2.zero;

            


            if(LineRender.Instance.MousePosFirst.y > LineRender.Instance.cancelCreateLinesPanel.transform.position.y)
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > LineRender.Instance.cancelLinesPanel.transform.position.y
                && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < LineRender.Instance.cancelDrawLinesPanelRoof.transform.position.y
                && !CancelPoolInput)
            {

                    if (Input.GetMouseButtonDown(0))
                    {
                        initialPosition = Input.mousePosition;
                        hold = tap = true;
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        release = true;
                        hold = false;
                        swipeDelta = (Vector2)Input.mousePosition - initialPosition;
                    }


                    if (hold)
                        swipeDelta = (Vector2)Input.mousePosition - initialPosition;

            }
            else
            {
                CancelPoolInput = true;
                //LineRender.Instance.BollIsrelease = false;// линия не отображается
                Ball.Instance.ballsPreview.parent.gameObject.SetActive(false);
                
                LineRender.Instance.line.SetPosition(0, new Vector2(0, 0));
                LineRender.Instance.line.SetPosition(1, new Vector2(0, 0));
            }

            if (Input.GetMouseButtonDown(0))
            {
                CancelPoolInput = false;
                hold = tap = true;
                initialPosition = Input.mousePosition;
            }



        }
    }


    
}
