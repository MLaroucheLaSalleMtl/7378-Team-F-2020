using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitUsed :MonoBehaviour
{
    private GameManager manager;
    public bool Ocupied = false;

    private void Start()
    {
       
        manager = GameManager.instance;

        if (transform.parent.tag == "Magic")
        {
            gameObject.tag = "MagicSit"+manager.NumberOfMagic;
        }
        else if(transform.parent.tag == "Haking"+manager.NumberOfHacking)
        {
            gameObject.tag = "HakingSit";
        }
        else if (transform.parent.tag == "AxeTrowing")
        {
            gameObject.tag = "AxeTrowingSit" + manager.NumberOfAxeTrowing;
        }
        else if (transform.parent.tag == "Surfing")
        {
            gameObject.tag = "SurfingSit" + manager.NumberOfSurfing;
        }

        if (transform.parent.GetComponent<ClasroomScip>().ChildTagName == null)
        {
            transform.parent.GetComponent<ClasroomScip>().ChildTagName = gameObject.tag;
        }
    }
}
