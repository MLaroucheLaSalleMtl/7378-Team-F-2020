using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildingmanager : MonoBehaviour
{
    public static Buildingmanager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    private string[] AvalableClases = { "Magic", "Axe Trowing", "Surfing", "Hacking"  };
    public GameObject[] ClassesPrefavs;
    private string[] Clasesbogth;
    List<string> Clases;
    private GameObject ClassToBuild;
    private void Start()
    {
        
    }
    public GameObject GetClassToBuild()
    {
        return ClassToBuild;
    }

    public void SetClass(GameObject Clasroom)
    {
        ClassToBuild= Clasroom;
    }
}
