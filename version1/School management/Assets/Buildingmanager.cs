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
    
    private string[] AvalableClases = { "Magic", "Surfing", "Haking", "Axe Trowing" };
    [SerializeField]private GameObject[] ClassesPrefavs;
    private string[] Clasesbogth;
    List<string> Clases;
    private GameObject ClassToBuild;
    private void Start()
    {
        ClassToBuild = ClassesPrefavs[0];
    }
    public GameObject GetClassToBuild() {
        return ClassToBuild;
    }
}
