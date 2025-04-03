using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int racesCompleted = 0;
    //public float[] leaderScore;
    
    private static GameData instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public static GameData Instance //пример энкапсуляции
    {
        get { return instance; }
    }
}
