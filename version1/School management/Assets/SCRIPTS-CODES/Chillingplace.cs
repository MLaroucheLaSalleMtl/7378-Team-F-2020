using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chillingplace : MonoBehaviour
{
    [SerializeField]private List<GameObject> Sits;
    private GameManager manager;
    [SerializeField]private int cost = 450;

    public int Cost { get => cost; set => cost = value; }



    //public int Cost { get => cost; set => cost = value; }

    private void Start()
    {
        manager = GameManager.instance;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "Sit")
            {
                GameObject a = transform.GetChild(i).gameObject;
                Sits.Add(a);
            }
        }

        manager.Chilingspot.Add(gameObject);

        for(int i = 0; i < manager.Allregisteredstudents.Count; i++)
        {
            if (manager.Allregisteredstudents[i].GetComponent<StudentMono>().Chillsit == null)
            {
                manager.Allregisteredstudents[i].GetComponent<StudentMono>().GetPlaceoncafeteria();
            }
        }
    }
    public bool IsthereSpace()
    {
        int count = 0;
        foreach (GameObject sit in Sits)
        {
            if (sit.GetComponent<SitUsed>().Ocupied == false)
                count++;

        }
        if (count > 0)
            return true;
        else return false;
    }
    public GameObject AvalableSit()
    {
        List<GameObject> tep = new List<GameObject>();
        foreach (GameObject sit in Sits)
        {
            if (sit.GetComponent<SitUsed>().Ocupied == false)
                tep.Add(sit);

        }
        int a = Random.Range(0, tep.Count);
        tep[a].GetComponent<SitUsed>().Ocupied = true;
        return tep[a];
    }

    void Update()
    {
        
    }
}
