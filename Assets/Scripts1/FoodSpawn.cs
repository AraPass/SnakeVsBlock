using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public int mincount;
    public int maxcount;
    
    //public float spawn_delay;
    public float spawn_dist;
    public GameObject[] PrefEat;

    //public Transform spawn_point;
    //public Vector3 volume;

    private void Awake()
    {
        int eatcount = Random.Range(mincount, maxcount);    

        for (int i = 0; i < eatcount; i++)
        {
            int eat_index = Random.Range(0, PrefEat.Length);
            GameObject eat_t = Instantiate(PrefEat[eat_index], transform);
            eat_t.transform.localPosition = new Vector3(Random.Range(-3, 2), 1f, spawn_dist * i);
        }

        



       //SSpawn();
    }

  /*  public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Wall>(out var walls))
            Destroy(gameObject);
    }
    /* public IEnumerator SSpawn()
     {
         int spawn_count = Random.Range(mincount, maxcount);
         GameObject parent = new GameObject();

         while (spawn_count > 0)
         {
             spawn_count--;
             Vector3 pos = new Vector3(Random.Range(spawn_point.position.x - volume.x, spawn_point.position.x + volume.x), -1.3f, Random.Range(spawn_point.position.z - volume.z, spawn_point.position.z + volume.z));
             GameObject obj = Instantiate(PrefEat, pos, Quaternion.identity, parent.transform);
             yield return new WaitForSeconds(spawn_delay);
         }
     }
    */
}
