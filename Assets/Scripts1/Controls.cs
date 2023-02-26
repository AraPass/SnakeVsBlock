using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Controls : MonoBehaviour
{
    public float speed;
    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = new Vector3 (Input.GetAxis("Mouse X")* speed * Time.deltaTime, 0, 0);
            transform.Translate(mouse * speed);

        }
    }
}
