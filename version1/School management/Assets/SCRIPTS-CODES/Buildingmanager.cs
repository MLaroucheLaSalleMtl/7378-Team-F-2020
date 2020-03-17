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

    //hover over color
    [SerializeField] private GameObject[] tempmap;

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

    public GameObject GetGostClass()
    {
        if (ClassToBuild != null)
        {
            if (ClassToBuild.tag == "Magic")
            {
                return tempmap[0];
            }
            else
            if (ClassToBuild.tag == "Haking")
            {
                return tempmap[1];
            }
            else
            if (ClassToBuild.tag == "AxeTrowing")
            {
                return tempmap[2];
            }
            else
            if (ClassToBuild.tag == "Surfing")
            {
                return tempmap[3];
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }


    }
}
