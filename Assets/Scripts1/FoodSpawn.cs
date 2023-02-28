using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public int min_spawn_count;
    public int max_spawn_count;
    public float disteat;
    public GameObject PrefEat;

    private void Awake()
    {
        int eatcount = Random.Range(min_spawn_count, max_spawn_count + 1);

        for (int  i = 0; i < eatcount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-40, 41), -1.3f, Random.Range(-40, 41));
            Instantiate(PrefEat, position, Quaternion.identity, PrefEat.transform);    
        }
    }
}
