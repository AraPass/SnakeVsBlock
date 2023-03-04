using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Food : MonoBehaviour
{
    
    public int points = 10;
    public GameObject Eat;


    void Update()
    {
        transform.Rotate(Vector3.up, 60 * Time.deltaTime);
    }

    public void Eating()
    {
        Game.points += points;
        Destroy(gameObject); 
        
    }

   /* public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Wall>(out var walls))
            Destroy(gameObject);
    }
   */
}
