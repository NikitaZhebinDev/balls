using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRender : MonoSingleton<LineRender>
{

    public Vector3 MousePosFirst;
    public Vector3 MousePosLast;
    public bool mouseup, mousedown;

    public bool BollIsrelease;

    public LineRenderer line;
    //public LineRenderer dottedLine;

    public float startWidth = 0.05f;
    public float endWidth = 0.05f;
    public Color startColor = Color.grey;
    public Color endColor = Color.grey;

    public GameObject cancelLinesPanel;
    public GameObject cancelDrawLinesPanelRoof;
    public GameObject cancelCreateLinesPanel;




    void Start()
    {

        MousePosFirst = new Vector3();
        MousePosLast = new Vector3();
        mouseup = false;
        mousedown = false;
        BollIsrelease = true;


        line = transform.GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.startWidth = startWidth;
        line.endWidth = endWidth;
        line.startColor = startColor;
        line.endColor = endColor;

        /*
        dottedLine.positionCount = 2;
        dottedLine.startWidth = startWidth;
        dottedLine.endWidth = endWidth;
        dottedLine.startColor = startColor;
        dottedLine.endColor = endColor;
        */
    }






    void Update()
    {
        if (!PauseMenu.Instance.isPause)
        {



            if (Input.GetMouseButtonDown(0))
            {
                MousePosFirst = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                MousePosFirst.z = 0;
                mousedown = true;

                //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition).y +" =? "+ Ball.Instance.transform.position.y);
            }
            else if (Input.GetMouseButtonUp(0))
            {

                OnDrawGizmosSelected();
                mouseup = true;

            }
            MousePosLast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePosLast.z = 0;
            OnDrawGizmosSelected();




        }
    }


    public void OnDrawGizmosSelected()
    {

        if (mousedown == true)
        {
            if (BollIsrelease)  // когда последний шар приземлился
            {
                line.SetPosition(0, MousePosFirst);
                line.SetPosition(1, MousePosLast);

                //float difX = MousePosFirst.x - Ball.Instance.ballNewStartPosition.transform.position.x;
                //float difY = MousePosFirst.y - Ball.Instance.ballNewStartPosition.transform.position.y;

                //dottedLine.SetPosition(0, Ball.Instance.ballNewStartPosition.transform.position);
                //dottedLine.SetPosition(1, new Vector3(MousePosLast.x - difX, MousePosLast.y - difY, 0.0f));
            }
            if (mouseup == true)
            {
                line.SetPosition(0, new Vector2(0, 0));
                line.SetPosition(1, new Vector2(0, 0));

                //dottedLine.SetPosition(0, new Vector2(0, 0));
                //dottedLine.SetPosition(1, new Vector2(0, 0));

                mousedown = false;
                mouseup = false;
            }


        }


    }
}

