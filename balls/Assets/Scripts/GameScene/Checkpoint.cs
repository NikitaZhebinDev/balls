using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoSingleton<Checkpoint> {


    public GameObject CheckpointText;
    public GameObject Particles;


    public void PlayCheckpointAnim()
    {
        CheckpointText.SetActive(true);
        Particles.SetActive(true);
        StartCoroutine(SetctiveFalse());
        Ball.Instance.checkPointText.text = "Check Point:\n" + Ball.Instance.score.ToString();
    }



    private IEnumerator SetctiveFalse()
    {
        yield return new WaitForSeconds(1.40f);

        CheckpointText.SetActive(false);
        Particles.SetActive(false);
    }


}
