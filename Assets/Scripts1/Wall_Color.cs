using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wall_Color : MonoBehaviour
{
    public Material MAT;
 

    void Start()
    {
        StartCoroutine("ChangeColor");

    }

   
    void Update()
    {
        //MAT.color = Random.ColorHSV();
    }


    IEnumerator ChangeColor()
    {
        Material material = this.GetComponent<Renderer>().material;
        while (true)
        {
            material.color = new Color(Random.value, Random.value, Random.value, 1);
            yield return new WaitForSeconds(2f);
        }
    }
   
}
