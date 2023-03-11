using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static Player;

public class Wall : MonoBehaviour
{


    public int mincount;
    public int maxcount;

    
    public int[] WallNumbers;
    public TextMeshPro Text;
    public int wallcount1;

   
    

    public void Awake()
    {

        
        int wallcount = Random.Range(mincount, maxcount);
        for (int i = 0; i < wallcount; i++)
        {
            Text.text = wallcount.ToString();
            
        }

        wallcount1 = wallcount;


    }

    public void SnakeDestroy()
    {
        
        Destroy(gameObject);
        //int wallCC = GetComponent<Wall>().wallcount1;
        //int lenght = Lenght;

       /* if (lenght > wallCC)
        {
        
            Destroy(gameObject);
           
        }
        else
        {
            
            Debug.Log("game over");

        }*/

    }

    public void Wall_Crash_Music()
    {
        AudioSource wallaudio = GetComponent<AudioSource>();
        wallaudio.Play();
    }

    
    //Text.text = WallNumbers[Random.Range(0, WallNumbers.Length + 1)];

    //int WallNumbers = Random.Range(mincount, maxcount);
    //Text = GetComponent<TextMeshPro>(); // получаем компонент Text на текущем объекте
    //Text.text = WallNumbers.ToString();
    /* public void ScoreChange()
     {

         Text.text = WallNumbers.ToString();
     }

     /*public void OnTriggerEnter(Collider other)
     {
         //print(collision.gameObject);
         //if (collision.collider.TryGetComponent<Player>(out var Head))
         Debug.Log("game over");

      }

     /*public void OnControllerColliderHit(ControllerColliderHit hit)
     {
         Debug.Log("game over");
         /*if (!hit.rigidbody.TryGetComponent<Player>(out var Head))
         {
             Debug.Log("game over");
         }
         */


}
