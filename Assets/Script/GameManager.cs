using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public static GameManager Instance
    {
        get 
        {
            if(instance==null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    private static GameManager instance;

    private GameManager()
    {
        sheetList = new List<Sheet>();
    }

    public float noteSpeed;

    public List<Sheet> sheetList;
    public Sheet sheet;
    public ScoreData score;

    public int songIndex;
    public int songCount;

    public float pauseTime;
}
