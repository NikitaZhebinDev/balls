using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockContainer : MonoSingleton<BlockContainer>
{

    public bool ROW_IS_MOVING;
    public bool ROW_IS_MOVING_BACK;
    private Vector3 newRowPosition;
    private Vector3 newExactRowPosition;

    private float offsetY = 0.0f;
    private float blockHeight = 0.0f; 

    private const float offsetBetweenBlocks = 0.011f;


    public GameObject rowPrefab;
    public Transform rowContainer;
    public GameObject blockPrefab;
    public RectTransform alignPanel;


    public GameObject gameOverPanel; // for Block Script
    public GameObject TurnOnWarningPanel; // for Block Script
    public GameObject WarningPanel; // for Block Script



    private void Start()
    {
        ROW_IS_MOVING = false;
        ROW_IS_MOVING_BACK = false;


        blockHeight = blockPrefab.transform.lossyScale.y * blockPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.y 
            + offsetBetweenBlocks;

        offsetY = blockHeight / 2;
    }





    float iterSpeed = 3;
    private void Update()
    {

        if (ROW_IS_MOVING && rowContainer.transform.position != newRowPosition && !ROW_IS_MOVING_BACK)
        {

            // Moving of the Old Row
            rowContainer.transform.position = Vector2.MoveTowards(
                rowContainer.transform.position,
                newRowPosition,
                   Time.deltaTime * iterSpeed);
            if(iterSpeed > 1f) iterSpeed -= 0.04f;
            if (iterSpeed < 1f) iterSpeed = 1.0f;

        }
        else if (ROW_IS_MOVING && rowContainer.transform.position == newRowPosition && !ROW_IS_MOVING_BACK)
        {

            ROW_IS_MOVING_BACK = true;

        }
        else if (ROW_IS_MOVING && ROW_IS_MOVING_BACK && rowContainer.transform.position != newExactRowPosition)
        {

            // Moving of the Old Row
            rowContainer.transform.position = Vector2.MoveTowards(
                rowContainer.transform.position,
                newExactRowPosition,
                   Time.deltaTime*iterSpeed);
            if (iterSpeed < 5.0f) iterSpeed += 0.0f;

        }
        else if(ROW_IS_MOVING)
        {

            GenerateNewRow();
            ROW_IS_MOVING = false;
            ROW_IS_MOVING_BACK = false;

        }
        else
        {

            ROW_IS_MOVING = false;
            ROW_IS_MOVING_BACK = false;

        }
           

    }
    

    
    


    public void GenerateNewRow()
    {
 
        GameObject newRow = Instantiate(rowPrefab) as GameObject;
        newRow.transform.SetParent(rowContainer);
        newRow.transform.localScale = new Vector3(1.27f, 1.27f, 1.27f);
        newRow.transform.position = new Vector3(0, alignPanel.position.y, 0.0f);

        newRow.transform.localPosition = new Vector3(newRow.transform.localPosition.x, newRow.transform.localPosition.y, 0.0f);




        Block[] blockArray = newRow.GetComponentsInChildren<Block>(); // get our 7 blocks




        int ballSpawnRandomIndex = Random.Range(0, 6);
        if (Ball.Instance.score == 1)
            ballSpawnRandomIndex = -1;






        //////////////////  Diamond Spawn  //////////////////

        int diamondRandomIndex = 0;
        if (((Ball.Instance.score % 10 == 0 && PlayerPrefs.GetInt("SavedAmountBalls") != Ball.Instance.score) 
            || (Ball.Instance.score == 1 && Random.Range(1, 10) > 8))
            && (Random.Range(1, 10) > 4))
        {
            do
            {
                diamondRandomIndex = Random.Range(0, 6);
            } while (diamondRandomIndex == ballSpawnRandomIndex);
        }
        else
        {
            diamondRandomIndex = -1;
        }

        //////////////////  Diamond Spawn  //////////////////






        bool wasSpawnedAtLeastOneBlock = false;



        for (int i = 0; i < blockArray.Length; i++)
        {


          

            if (ballSpawnRandomIndex == i)
            {
                blockArray[i].SpawnBall();
            }
            else if (diamondRandomIndex == i)
            {
                blockArray[i].SpawnDiamond();
            }
            else 
            {
                // Random amount of blocks in the row
                if (Random.Range(1, 10) > Random.Range(4, 6))
                {
                    blockArray[i].Spawn();
                    //Debug.Log("Spawn block: " + (i+1) + ".");
                    wasSpawnedAtLeastOneBlock = true;
                }
                else
                {
                    // if all blocks are hided => we spawn random one block
                    if (!wasSpawnedAtLeastOneBlock && i == blockArray.Length - 1)
                    {
                        blockArray[i].Spawn();
                    }
                    else
                    {
                        blockArray[i].Hide();
                        //Debug.Log("Hide block: " + (i + 1) + ".");
                    }
                }
            }


        }
        


        
    }




    
    public void MoveOldRow()
    {
        
        newRowPosition = new Vector3(rowContainer.transform.position.x,
               rowContainer.transform.position.y
               - blockHeight - offsetY,
               0.0f);

        newExactRowPosition = new Vector3(rowContainer.transform.position.x,
               rowContainer.transform.position.y
               - blockHeight,
               0.0f);

        iterSpeed = 3;

        ROW_IS_MOVING = true;
        
    }

    
    






}
