using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caffeteria : MonoBehaviour
{
    public List<GameObject> Sits;
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "Sit")
            {
                Sits.Add(transform.GetChild(i).gameObject);
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
