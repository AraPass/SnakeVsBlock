using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //public bool Crash = true;

    public void OnCollisionEnter(Collision collision)
     {
        print(collision.gameObject);
        //if (!collision.collider.TryGetComponent<Player>(out var Head))
        //Debug.Log("game over");

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
