using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBall : MonoBehaviour
{
    private bool collected;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected)
        {
            collected = true;
            Destroy(this.gameObject);
            Ball.Instance.CollectBall();
        }
    }
}
