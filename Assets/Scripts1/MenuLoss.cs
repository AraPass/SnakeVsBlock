using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoss : MonoBehaviour
{
    [SerializeField] Player player;

    public GameObject menu;
    public GameObject level;
    public void CanvasMenuLossEnable()
    {
        menu.SetActive(true);
        level.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CanvasMenuLossEnable();
            
    }
}
