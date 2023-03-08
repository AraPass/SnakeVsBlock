using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryLoss : MonoBehaviour
{

    [SerializeField] Player player;
    public GameObject retry;
    public GameObject menu;

    /* private void Buttons()
     {
         player.ReloadLevel();
     }

     public void CanvasMenuLossEnable()
     {

         menu.SetActive(true);

     }
    */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            
        player.ReloadLevel();
    }
}
