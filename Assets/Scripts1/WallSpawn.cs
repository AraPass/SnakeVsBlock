using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    public int mincount;
    public int maxcount;

    public float spawn_dist;
    public GameObject[] PrefWalls;
    public Transform FinishWall;
    public Transform Road;
    //public float ExtraRoadScale = -10f;

    private void Awake()
    {
        int wallcount = Random.Range(mincount, maxcount);

        for (int i = 0; i < wallcount; i++)
        {
            int wall_index = Random.Range(0, PrefWalls.Length);
            GameObject wall_t = Instantiate(PrefWalls[wall_index], transform);
            wall_t.transform.localPosition = CalculateWallsPos(i);
            //wall_t.transform.localPosition = new Vector3(-1.3f, 0.5f, spawn_dist * i);
        }

        FinishWall.localPosition = CalculateWallsPos(wallcount);

        Road.localScale = new Vector3 (1, 1, wallcount/13.5f);
    }

    private Vector3 CalculateWallsPos(int wall_index)
    {
        //return new Vector3(0, 0, spawn_dist * wall_index);
        return new Vector3(-1.3f, 0.5f, spawn_dist * wall_index);
    }

   
}
