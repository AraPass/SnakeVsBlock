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
        //GenerateNewFood(); 
    }

    public static void GenerateNewFood()
    {
        //GameObject Eat = (GameObject)Instantiate(Resources.Load("Prefabs/Eat", typeof(GameObject)));

        /*GameObject parent = new GameObject();
        Vector3 pose = new Vector3();
        GameObject obj = (GameObject)Instantiate(Resources.Load("Assets/Prefabs/Eat"), pose, Quaternion.identity, parent.transform);
        */
        //GameObject Eat = Instantiate(Eat,Eat.transform);

        /*while (true)
        {

            Eat.transform.position = new Vector3(Random.Range(-40, 41), -1.3f, Random.Range(-40, 41));
            Bounds bounds = Eat.GetComponent<Collider>().bounds; // Eat.GetComponent<GameObject>().bounds Bounds eatBounds =
            bool intersects = false;

            foreach (Collider objectColiider in FindObjectsOfType(typeof(Collider)).Cast<Collider>())
            {
                if (objectColiider != Eat.GetComponent<GameObject>())
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
        }*/


    }

}
