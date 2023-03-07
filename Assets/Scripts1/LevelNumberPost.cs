using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberPost : MonoBehaviour
{
    public Text Text;
    public Player Game;

    void Start()
    {
        Text.text = (Game.LevelIndex + 2).ToString();
    }


}
