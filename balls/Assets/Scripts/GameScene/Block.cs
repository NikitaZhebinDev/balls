using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{

    public GameObject blockObject;
    public GameObject ballObject;
    public GameObject diamond;


    public GameObject HP;



    public Gradient gradient;
    //public SpriteRenderer rendererSprite;


    private Animator animatorBlockHit;
    

    public int hp;
    private Text textHP;



    public GameObject blockDestr;
    public GameObject ballDestr;



    private void Start()
    {

        if (BlockContainer.Instance.WarningPanel.activeSelf)
            BlockContainer.Instance.WarningPanel.SetActive(false);

        //rendererSprite = blockObject.GetComponent<SpriteRenderer>();
        //rendererSprite.color = gradient.Evaluate(hp);


        textHP = HP.GetComponent<Text>();
        textHP.text = hp.ToString();

        animatorBlockHit = blockObject.GetComponent<Animator>();
    }


    


    private void Update()
    {
        // Warning
        if (BlockContainer.Instance.TurnOnWarningPanel.transform.position.y > blockObject.transform.position.y
            && BlockContainer.Instance.gameOverPanel.transform.position.y < blockObject.transform.position.y
            && blockObject.activeSelf
            && !BlockContainer.Instance.ROW_IS_MOVING && !BlockContainer.Instance.ROW_IS_MOVING_BACK)
        {
            if(!BlockContainer.Instance.WarningPanel.activeSelf)
                BlockContainer.Instance.WarningPanel.SetActive(true);
        }
       // else // WRONG CONDiTION !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //{
        //    Debug.Log("FAAAAAAAAALSE");
        //    if (BlockContainer.Instance.WarningPanel.activeSelf)
         //       BlockContainer.Instance.WarningPanel.SetActive(false);
        //}


        // Game Over
        if (BlockContainer.Instance.gameOverPanel.transform.position.y > blockObject.transform.position.y
            && blockObject.activeSelf 
            && !BlockContainer.Instance.ROW_IS_MOVING && !BlockContainer.Instance.ROW_IS_MOVING_BACK)
        {
            DestroyAllBlocksAndActiveGameOver();
        }


        // Get Ball Simple Destruction
        if (BlockContainer.Instance.gameOverPanel.transform.position.y > ballObject.transform.position.y
            && ballObject.activeSelf
            && !BlockContainer.Instance.ROW_IS_MOVING && !BlockContainer.Instance.ROW_IS_MOVING_BACK)
        {
            DestroyGetBall();
        }
    }





    public void Spawn()
    {
        if(Random.Range(1, 10) > 5)
        {
            hp = Ball.Instance.score;
        }
        else
        {
            hp = Ball.Instance.score * 2;
        }


        if (hp <= 0)
            hp = 1;
        

        HP.SetActive(true);


        float colorRender = (float)hp;
        while (colorRender > 100.0f)
        {
            colorRender -= 100.0f;
        }
        colorRender /= 100f;


        blockObject.GetComponent<SpriteRenderer>().color = gradient.Evaluate(colorRender);
    }



    public void SpawnBall()
    {

        blockObject.SetActive(false);
        HP.SetActive(false);

        ballObject.SetActive(true);

        this.blockDestr.SetActive(false);
        this.ballDestr.SetActive(false);

        gameObject.GetComponent<BoxCollider>().enabled = false;
    }







    public void SpawnDiamond()
    {

        blockObject.SetActive(false);
        HP.SetActive(false);
        ballObject.SetActive(false);

        diamond.SetActive(true);

        this.blockDestr.SetActive(false);
        this.ballDestr.SetActive(false);

        gameObject.GetComponent<BoxCollider>().enabled = false;
    }




    public void Hide()
    {

        //blockObject.SetActive(false);
        //HP.SetActive(false);

        Destroy(this.gameObject);

        //gameObject.SetActive(false);

    }







    
    public void ReceiveHit()
    {
        hp--;
        
        textHP.text = hp.ToString();

        

        float colorRender = (float)hp;
        while (colorRender > 100.0f)
        {
            colorRender -= 100.0f;
        }
        colorRender /= 100f;
        blockObject.GetComponent<SpriteRenderer>().color = gradient.Evaluate(colorRender);

        

        if (hp <= 0)
        {

            DestroyBlock();

            //////////////////////////  Checkpoint!  //////////////////////////
            if (GameObject.FindGameObjectsWithTag("Block").Length < 1)
            {
                AudioBuyBall.Instance.PlaySoundBuyBall();

                print("Check Point !!!!");
                PlayerPrefs.SetInt("SavedAmountBalls", Ball.Instance.score);

                Ball.Instance.ReturnBalls();
                Checkpoint.Instance.PlayCheckpointAnim();
            }
            //////////////////////////  Checkpoint!  //////////////////////////


            //Destroy(this.gameObject); // будем разрушать потом всю строку при столкновении с солайдером нижней границы
        }
        else
        {
            animatorBlockHit.Play("AnimBlockHit 0", animatorBlockHit.GetLayerIndex("Base Layer"));
            //animatorBlockHit.SetBool("hitAnim", true);
        }
        
    }






    public void DestroyBlock()
    {

        // Desctruction !!!!!!!!!!!!
        blockDestr.GetComponent<ParticleSystem>().Emit(10);
        
        blockObject.SetActive(false);
        HP.SetActive(false);

        gameObject.GetComponent<BoxCollider>().enabled = false;
       
    }
    public void DestroyGetBall()
    {
        if (ballObject.activeSelf)
        {
            // Desctruction !!!!!!!!!!!!
            //ballDestr.GetComponent<ParticleSystem>().Emit(25);

            this.ballDestr.SetActive(true);

            ballObject.SetActive(false);
        }
    }





    public void DestroyAllBlocksAndActiveGameOver()
    {

        if (OneMoreChanceAd.Instance.rewardBasedVideo.IsLoaded())
        {
            OneMoreChanceAd.Instance.ShowOneMoreChancePanel();
        }
        else {

            Block[] blocks = GameObject.FindObjectsOfType<Block>();

            foreach (Block block in blocks)
            {
                block.DestroyBlock();
                block.DestroyGetBall();
            }


            //PlayerPrefs.SetInt("SavedAmountBalls", 1);


            GameOver.Instance.PlayGameOverAnim();
            AudioBlockDestruction.Instance.PlaySoundBlockDestruction();
        }


    }









}
