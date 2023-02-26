using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Food : MonoBehaviour
{
    
    public int points = 10;
    //public GameObject Eat;
 

    void Update()
    {
        transform.Rotate(Vector3.up, 60 * Time.deltaTime);
    }

    public void Eating()
    {
        Game.points += points;
        Destroy(gameObject); 
        GenerateNewFood(); 
    }

    public static void GenerateNewFood()
    {
        GameObject Eat = (GameObject)Instantiate(Resources.Load("Prefabs/Eat", typeof(GameObject)));

        


        while (true)
        {
            Eat.transform.position = new Vector3(Random.Range(-40, 41), 0, Random.Range(-40, 41));
            Bounds bounds = Eat.GetComponent<Collider>().bounds; // Eat.GetComponent<GameObject>().bounds Bounds eatBounds =
            bool intersects = false;

            foreach (Collider objectColiider in FindObjectsOfType(typeof(Collider)).Cast<Collider>())
            {
                if (objectColiider != Eat.GetComponent<Collider>())
                {
                    if (objectColiider.bounds.Intersects(bounds))
                    {
                        intersects = true;
                        break;
                    }
                }
            }

            if (!intersects)
            {
                break;
            }
        }


    }

}
