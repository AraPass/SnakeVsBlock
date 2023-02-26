using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}
