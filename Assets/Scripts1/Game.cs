using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int points;

    private string _pointsString; 
    private int _lastPonts = -1;
    

    public void Awake()
    {
        points = 10;
        //Food.GenerateNewFood();
    
    }

    
    void Update()
    {
        if (_lastPonts == points) return;
        _lastPonts = points;
        _pointsString = "Score: " + points.ToString("0000");
    }

    

}
