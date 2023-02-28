using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    public int mincount;
    public int maxcount;

    public float spawn_dist;
    public GameObject[] PrefWalls;

    private void Awake()
    {
        int wallcount = Random.Range(mincount, maxcount);

        for (int i = 0; i < wallcount; i++)
        {
            int wall_index = Random.Range(0, PrefWalls.Length);
            GameObject wall_t = Instantiate(PrefWalls[wall_index], transform);
            wall_t.transform.localPosition = new Vector3(-1.3f, 0.5f, spawn_dist * i);
        }
    }
}
