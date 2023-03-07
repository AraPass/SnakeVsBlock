using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour
{

    public Text Text;
    public Player Game;

    void Start()
    {
        Text.text = (Game.LevelIndex + 1).ToString();
    }

    
}
