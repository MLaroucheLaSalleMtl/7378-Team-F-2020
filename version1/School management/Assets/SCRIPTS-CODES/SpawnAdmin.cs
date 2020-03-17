using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAdmin : MonoBehaviour
{
    public static SpawnAdmin instance = null;
    private tasks Tasks;


    //GostyStuff
    [SerializeField]private GameObject tempmap;
    private GameObject clone;

    [SerializeField] private GameObject tooltip;
    
    //...

    [SerializeField] private GameObject Admin;
    [SerializeField] private Vector3 PossitionOfcet;

    private int adminmade;

    public int AdminMade { get => adminmade; set => adminmade = value; }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            //Destroy(gameObject);
        }
    }


    void Start()
    {
        Tasks = tasks.instance;
    }
    

    private void OnMouseDown()
    {

        Instantiate(Admin, transform.position + PossitionOfcet, transform.rotation);
        AdminMade = 1;
        Destroy(clone);
        Tasks.SparklesForObj[3].SetActive(false);
        Destroy(gameObject);
        tooltip.SetActive(false);
    }

    private void OnMouseEnter()
    {
        tooltip.SetActive(true);
        clone = Instantiate(tempmap, transform.position + PossitionOfcet, transform.rotation);
        
       
    }
    private void OnMouseExit()
    {
        tooltip.SetActive(false);
        Destroy(clone);
    }
}
