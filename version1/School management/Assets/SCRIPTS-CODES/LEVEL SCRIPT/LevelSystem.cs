using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance = null;

    #region instance
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            //Destroy(gameObject);
        }
    }
    #endregion

    public event EventHandler onExpChange;
    public event EventHandler onLvlChange;

    private int level;
    private int exp;
    private int expToNextLevel;

    public LevelSystem()
    {
        level = 0;
        exp = 0;
        expToNextLevel = 100;
    }

    public void addExp(int amount)
    {
        exp += amount;
        if (exp >= expToNextLevel)
        {
            //Enough to exp to next level
            level++;
            exp -= expToNextLevel;
            if (onLvlChange != null) onLvlChange(this, EventArgs.Empty);
        }

        if (onExpChange != null) onExpChange(this, EventArgs.Empty);
    }

    public int GetLvLNum()
    {
        return level;
    }


    public float GetExpNormalized()
    {
        return (float)exp / expToNextLevel;
    }

    
}
