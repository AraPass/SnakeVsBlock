using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static int points;

    private string _pointsString; 
    private int _lastPonts = -1;
    

    public void Awake()
    {
        points = 10;
        
    
    }

    
    void Update()
    {
        if (_lastPonts == points) return;
        _lastPonts = points;
        _pointsString = "Score: " + points.ToString("0000");
    }


  /*  public void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
  */
    
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";

    /* public void ReloadLevel()
     {
         SceneManager.LoadScene(1);
     }

     //SceneManager.GetActiveScene().buildIndex
    */
}
