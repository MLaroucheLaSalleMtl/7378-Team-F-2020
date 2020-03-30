using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class lvlTesting : MonoBehaviour
{
    [SerializeField] private LevelUI levelUI;

    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        levelUI.setLvlSystem(levelSystem);
    }

    
}
