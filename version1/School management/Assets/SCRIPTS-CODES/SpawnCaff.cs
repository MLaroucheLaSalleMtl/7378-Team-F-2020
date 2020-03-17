using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCaff : MonoBehaviour
{

    public static SpawnCaff instance = null;
    private tasks Tasks;


    //GostyStuff
    [SerializeField] private GameObject tempmap;
    private GameObject clone;

    [SerializeField] private GameObject tooltip;

    //...

    [SerializeField] private GameObject Caff;
    [SerializeField] private Vector3 PossitionOfcet;

    private int caffmade;

    public int CaffMade { get => caffmade; set => caffmade = value; }


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


    // Start is called before the first frame update
    void Start()
    {
        Tasks = tasks.instance;
    }

    private void OnMouseDown()
    {

        Instantiate(Caff, transform.position + PossitionOfcet, transform.rotation);
        CaffMade = 1;
        Destroy(clone);
        Tasks.SparklesForObj[4].SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
