using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAdmin : MonoBehaviour
{
    //GostyStuff
    [SerializeField]private GameObject tempmap;
    private GameObject clone;
    //...
    
    [SerializeField] private GameObject Admin;
    [SerializeField] private Vector3 PossitionOfcet;
    void Start()
    {
     
    }
    

    private void OnMouseDown()
    {
        
        Instantiate(Admin, transform.position + PossitionOfcet, transform.rotation);
        Destroy(clone);
        Destroy(gameObject);
    }

    private void OnMouseEnter()
    {
        clone = Instantiate(tempmap, transform.position + PossitionOfcet, transform.rotation);
       
    }
    private void OnMouseExit()
    {
        Destroy(clone);
    }
}
