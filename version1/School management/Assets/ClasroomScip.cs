using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasroomScip : MonoBehaviour
{
    public int ClassCost;
    public GameObject[] Sits;
    public string ChildTagName;
    private void Awake()
    {
        ChildTagName = null;
    }

    private void Update() 
        {
            if (ChildTagName != null)
                Sits = GameObject.FindGameObjectsWithTag(ChildTagName);
        }
    public bool IsthereSpace()
    {
        int count=0;
        foreach (GameObject sit in Sits)
        {
            if (sit.GetComponent<SitUsed>().Ocupied==false)
                count++;
           
        }
        if (count < Sits.Length)
            return true;
        else return false;
    }
    public GameObject AvalableSit()
    {
        List<GameObject> tep = new List<GameObject>();
        foreach (GameObject sit in Sits)
        {
            if (sit.GetComponent<SitUsed>().Ocupied==false)
                tep.Add(sit);
            
        }
        int a = Random.Range(0, tep.Count);
        tep[a].GetComponent<SitUsed>().Ocupied = true;
        return tep[a];
    }
}
