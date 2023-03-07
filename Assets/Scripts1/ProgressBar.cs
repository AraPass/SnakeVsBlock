using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
   public Player player;
    public Transform Finish;
    public Slider progress;

    private float startpose;

    private void Start()
    {
        startpose = player.transform.position.z;
    }

    private void Update()
    {
        float currentZ = player.transform.position.z;
        float finishZ = Finish.position.z;

        float t = Mathf.InverseLerp(startpose, finishZ, currentZ);
        progress.value = t;
    }
}
