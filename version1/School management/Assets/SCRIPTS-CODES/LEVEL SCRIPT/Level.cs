using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int maxExp;
    public float updatedExp;

    public Text leveltext;
    public Image Expbar;

    // public float addExp;
    public int expIncrease;
    public int playerLevel;

    // Start is called before the first frame update
    void Start()
    {
        playerLevel = 1;
        maxExp = 50;
        updatedExp = 0;
        Expbar.fillAmount = 0;

    }

    public void addExp(int expIncrease)
    {
        //expIncrease = amount;
        updatedExp += expIncrease;
        Expbar.fillAmount = updatedExp / maxExp;
    }

    public void levelUp()
    {

        if (updatedExp >= maxExp)
        {
            playerLevel++;
            updatedExp = 0;
            maxExp += maxExp-50;
        }
    }
  
    
    void Update()
    {
        leveltext.text = "Level: " + playerLevel;

        levelUp();
    }
}
