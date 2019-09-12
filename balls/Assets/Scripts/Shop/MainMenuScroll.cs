using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScroll : MonoBehaviour {

    [Header("Selected Panel")]
    public int selectedPanel = 0;

    [Header("Last Selected Panel")]
    public int lastSelectedPanel = 0;


    [Header("Scale Smooth Steps")]
    public bool scaleSmoothSteps = false;


    [Range(1, 50)]
    [Header("Controllers")]
    public int panCount;
    [Range(0, 500)]
    public int panOffset;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f, 10f)]
    public float scaleOffset;
    [Range(1f, 20f)]
    public float scaleSpeed;
    [Header("Other Objects")]




    // Must be initialized in ANY WAY!
    public GameObject panPrefab;              // Our Panels (Get from Unity UI)
    //private GameObject improvementInterface;  // Child object of panelPrefab

    public ScrollRect scrollRect;             // FOR inertia
    public float minScalePan, maxScalePan;    // min & max scales for Panel
    public float additionalSpace;             // Additional space between out Panels



    public GameObject windowStandart;
    public GameObject windowRare;
    public GameObject windowGold;
    public GameObject windowEpic;


    private GameObject[] spawnedPanels;       // saving spawned objects
    private Vector2[] pansPos;                // Panels positions
    private Vector2[] pansScale;

    private RectTransform contentRect;        // RectTransform of CONTENT
    private Vector2 contentVector;

    private int selectedPanID;

    private bool isScrolling;

    private int i = 0; // for loops (mb it's a little bit of optimization)




    private float nearestPos;
    private float distance;



    //// Warning Panels ////
    public Image WarningPanelLeft;
    public Image WarningPanelRight;
    //// Warning Panels ////





    private void Start()
    {
        contentRect = GetComponent<RectTransform>();

        spawnedPanels = new GameObject[panCount];

        pansPos = new Vector2[panCount];
        pansScale = new Vector2[panCount];

        spawnedPanels[0] = windowStandart;
        spawnedPanels[1] = windowRare;
        spawnedPanels[2] = windowGold;
        spawnedPanels[3] = windowEpic;

        // Initilize my Panels
        //spawnedPanels[0] = Instantiate(windowAdventure, transform, false);
        //spawnedPanels[1] = Instantiate(windowCups, transform, false);
        //spawnedPanels[2] = Instantiate(windowShop, transform, false);


        for (int i = 0; i < panCount; i++)
        {

            // created and added Panel to array  // Instantiate - create object | panPrefab - what we creat, transform - where we creat it
            //spawnedPanels[i] = Instantiate(panPrefab, transform, false); // скрипт на контенте => трансформ и есть контент | false значит, что мы юзаем только локальные координаты


            

            if (i == 0) continue; // позиция 0 панельки не учитывается

            // устанваливаем позицию кажой панели                                                     
            spawnedPanels[i].transform.localPosition = new Vector3(spawnedPanels[i - 1].transform.localPosition.x
                + panPrefab.GetComponent<RectTransform>().sizeDelta.x
                + panOffset + additionalSpace,
                spawnedPanels[i].transform.localPosition.y,
                -1);

            // закидываем в массив позиций панелей
            pansPos[i].x = -spawnedPanels[i].transform.localPosition.x;
            pansPos[i].y = -spawnedPanels[i].transform.localPosition.y;


        }




    }







    private void FixedUpdate() // обновляется в зависимости от фпса 
    {


        // due to inertia мы не улетали далеко при сильном скроллинге
        if (contentRect.anchoredPosition.x >= pansPos[0].x && !isScrolling || contentRect.anchoredPosition.x <= pansPos[pansPos.Length - 1].x && !isScrolling)
        {
            scrollRect.inertia = false; // если не скролится, то выключаем инерцию
        }


        // nearest to Panel
        // в начале макс позиция, чтобы при переборе в цикле он уменьшался и шел к меньшему
        nearestPos = float.MaxValue;

        if (scrollRect.inertia)
        {

            for (i = 0; i < panCount; i++)
            {
                //print("i'm here " + contentRect.anchoredPosition.x);
                //print("Panel "+i+": " + pansPos[i].x);

                //////////////// !! nearest Panel to CONTENT (to ur screen) !! ////////////////
                // nearest to Panel
                // abs - абсолютн значение (моуль)
                distance = Mathf.Abs(contentRect.anchoredPosition.x - pansPos[i].x);

                if (distance < nearestPos)
                {
                    nearestPos = distance;
                    selectedPanID = i;
                }

                selectedPanel = selectedPanID;



                if (selectedPanel == 0) // Standart
                {
                    WarningPanelLeft.color = new Color(64, 242, 141); // green
                    WarningPanelRight.color = new Color(64, 242, 141); // green
                }
                else if (selectedPanel == 1) // Rare
                {
                    WarningPanelLeft.color = new Color(64, 178, 255); // blue
                    WarningPanelRight.color = new Color(64, 178, 255); // blue
                }
                else if (selectedPanel == 2) // Gold
                {
                    WarningPanelLeft.color = new Color(255, 207, 64); // golden
                    WarningPanelRight.color = new Color(255, 207, 64); // golden
                }
                else if (selectedPanel == 3) // Epic
                {
                    WarningPanelLeft.color = new Color(222, 79, 255); // purple
                    WarningPanelRight.color = new Color(222, 79, 255); // purple
                }



                /////////////////////////  SCALE  ///////////////////////////
                // 1 - полный размер обьекта
                if (scaleSmoothSteps)
                {
                    float scale = Mathf.Clamp(1 / (distance / panOffset) * scaleOffset, minScalePan, maxScalePan);

                    pansScale[i].x = Mathf.SmoothStep(spawnedPanels[i].transform.localScale.x,
                        scale + 0.3f, scaleSpeed * Time.fixedDeltaTime);
                    pansScale[i].y = Mathf.SmoothStep(spawnedPanels[i].transform.localScale.y,
                        scale + 0.3f, scaleSpeed * Time.fixedDeltaTime);

                    spawnedPanels[i].transform.localScale = pansScale[i];
                }
                /////////////////////////  SCALE  ///////////////////////////
            }
        }
        else
        {
            lastSelectedPanel = selectedPanel;
        }


        // If KeyCode *BACK* was pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }


        //computing nearestPanel except current
        /*Debug.Log("FirsttPos: " + pansPos[0].x);
        Debug.Log("SecondPos: " + pansPos[1].x);
        Debug.Log("ThirstPos: " + pansPos[2].x);
        Debug.Log("contentRect.anchoredPosition.x: " + contentRect.anchoredPosition.x);*?


        // min Distance between screen and nearesPanel except current
        float minvDistance = pansPos[0].x - contentRect.anchoredPosition.x; 
        
            /*if (iter != selectedPanel && (Mathf.Abs(pansPos[iters].x - contentRect.anchoredPosition.x)) < minvDistance)
            {
                nearestPanel = iter;
            }*/



       
        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);

        // TURN OFF inertia (без дерганой аним. и с инерцией) & smooth stoping
        if (scrollVelocity < 400 && !isScrolling) scrollRect.inertia = false;



        // if true - не идем дальше
        if (isScrolling || scrollVelocity > 400) return; // if we scroll => не привязываем screen to Panel

       
        
        // отпустили скроллинг и наш контент подьехал к ближайшей пaнельки
        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, pansPos[selectedPanel].x, 
        snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;
        




    }
   






    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;

        // TURN ON inertia if we're scrolling
        if (scroll) scrollRect.inertia = true;
    }



    public void SelectWindow(int numWindow)
    {
        selectedPanel = numWindow;
    }




}
