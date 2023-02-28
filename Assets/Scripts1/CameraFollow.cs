using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform target;

    public Transform player;
    public Vector3 SnakeHeadCam;
    public float speed;

    public void FixedUpdate()
    {
        if (player != null)
        {
            transform.LookAt(player);
        }
       

        Vector3 Pposition = player.transform.position + SnakeHeadCam;
        var nextpose = Vector3.Lerp(transform.position, Pposition + SnakeHeadCam, speed * Time.fixedDeltaTime);
        transform.position = nextpose;
        //transform.position = Vector3.Lerp(transform.position, Pposition, speed * Time.fixedDeltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, Pposition, speed * Time.fixedDeltaTime);
        //position = position.normalized;

        //transform.LookAt(target);

    }
}
