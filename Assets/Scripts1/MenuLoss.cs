using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoss : MonoBehaviour
{
    [SerializeField] Player player;
    public float timer = 0;
    public GameObject menu;
   
    
    public void CanvasMenuLossEnable()
    {

        menu.SetActive(true);
       
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CanvasMenuLossEnable();
            player.enabled = false;
            //Invoke("CanvasMenuLossEnable", 40f);
            //Time.timeScale = timer;
            //Invoke("CanvasMenuLossEnable", 40f);

        }
       
            
    }
}
