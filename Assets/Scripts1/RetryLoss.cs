using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryLoss : MonoBehaviour
{

    [SerializeField] Player player;

    private void Buttons()
    {
        player.ReloadLevel();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Buttons();
    }
}
